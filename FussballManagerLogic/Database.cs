using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FussballManagerLogic
{
    public static class Database
    {
        public static bool CreateEmptyDatabase(SQLiteConnectionStringBuilder builder) // TODO: error handling
        {
            using (SQLiteConnection connection = new(builder.ToString()))
            {
                connection.Open();
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "create table Teams (ID integer not null primary key, Name varchar(25) not null unique)";
                command.ExecuteNonQuery();

                command.CommandText = "create table Players (ID integer not null primary key, Name varchar(25) not null unique, TeamID integer not null, Speed integer not null, Precision integer not null, Duel integer not null, Position integer not null)";
                command.ExecuteNonQuery();

                command.CommandText = "create table Season (ID integer not null primary key, TeamOne varchar(25) not null, TeamTwo varchar(25) not null, Day integer not null, Home integer not null, Visitor integer not null)";
                command.ExecuteNonQuery();
            }

            return true;
        }
        public static bool SaveTeamToDatabase(Team team)
        {
            SQLiteConnectionStringBuilder builder = new();
            builder.Version = 3;
            builder.DataSource = "GameDatabase.db";
            if (!File.Exists(builder.DataSource))
            {
                CreateEmptyDatabase(builder);
            }

            using (SQLiteConnection connection = new(builder.ToString()))
            {
                connection.Open();

                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "replace into Teams (Name) values (@Name);";
                command.Parameters.AddWithValue("@Name", team.Name);
                command.ExecuteNonQuery();

                command.CommandText = "select last_insert_rowid()";
                Int64 LastRowID64 = (Int64)command.ExecuteScalar();
                int LastRowID = (int)LastRowID64;

                command.CommandText = "replace into Players (Name, TeamID, Speed, Precision, Duel, Position) values (@Name, @TeamID, @Speed, @Precision, @Duel, @Position);";

                int linesAffected = 0;
                foreach (Player player in team.Players)
                {
                    command.Parameters.AddWithValue("@Name", player.Name);
                    command.Parameters.AddWithValue("@TeamID", LastRowID);
                    command.Parameters.AddWithValue("@Speed", player.Speed);
                    command.Parameters.AddWithValue("@Precision", player.Precision);
                    command.Parameters.AddWithValue("@Duel", player.Duel);
                    command.Parameters.AddWithValue("@Position", player.Position);

                    linesAffected += command.ExecuteNonQuery();
                }

                if (linesAffected == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool SaveSeasonToDatabase(Saison saison)
        {
            SQLiteConnectionStringBuilder builder = new();
            builder.Version = 3;
            builder.DataSource = "GameDatabase.db";
            if (!File.Exists(builder.DataSource))
            {
                CreateEmptyDatabase(builder);
            }

            using (SQLiteConnection connection = new(builder.ToString()))
            {
                connection.Open();

                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "replace into Season (TeamOne, TeamTwo, Day, Home, Visitor) values (@TeamOne, @TeamTwo, @Day, @Home, @Visitor);";

                int linesAffected = 0;
                foreach (Match match in saison.Matches)
                {
                    command.Parameters.AddWithValue("@TeamOne", match.TeamOne.Name);
                    command.Parameters.AddWithValue("@TeamTwo", match.TeamTwo.Name);
                    command.Parameters.AddWithValue("@Day", match.Day);
                    command.Parameters.AddWithValue("@Home", match.Home);
                    command.Parameters.AddWithValue("@Visitor", match.Visitor);

                    linesAffected += command.ExecuteNonQuery();
                }

                if (linesAffected == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static List<Standing> GetStandingsFromDatabase(int day)
        {
            SQLiteConnectionStringBuilder builder = new();
            builder.Version = 3;
            builder.DataSource = "GameDatabase.db";

            List<Standing> Standings = new List<Standing>();

            using (SQLiteConnection connection = new(builder.ToString()))
            {
                connection.Open();
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT TeamOne, SUM(Home) AS SumHome, SUM(Visitor) AS SumVisitor, " +
                    "((SELECT COUNT (*) FROM Season WHERE Home > Visitor AND O.TeamOne = TeamOne AND Day <= @Day)   +   (SELECT COUNT (*) FROM Season WHERE Home < Visitor AND O.TeamTwo = TeamOne AND Day <= @Day)) AS TWon, " +
                    "(SELECT COUNT (*) FROM Season WHERE Home = Visitor AND O.TeamOne = TeamOne AND Day <= @Day OR Home = Visitor AND O.TeamOne = TeamTwo AND Day <= @Day) AS TDraw, " +
                    "((SELECT COUNT (*) FROM Season WHERE Home < Visitor AND O.TeamOne = TeamOne AND Day <= @Day)   +   (SELECT COUNT (*) FROM Season WHERE Home > Visitor AND O.TeamTwo = TeamOne AND Day <= @Day)) AS TLost " +
                    "FROM Season O WHERE Day <= @Day GROUP BY TeamOne;"; //TODO: sql command correctness
                command.Parameters.AddWithValue("@Day", day);

                using (SQLiteDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.KeyInfo))
                {
                    while (reader.Read())
                    {
                        Standings.Add(new Standing() //TODO: insert correct values
                        {
                            TeamName = (string)reader["TeamOne"],
                            Games = day,
                            Points = (Convert.ToInt32(reader["TWon"]) * 3) + Convert.ToInt32(reader["TDraw"]),
                            GoalsHome = Convert.ToInt32(reader["SumHome"]),
                            GoalsVisitor = Convert.ToInt32(reader["SumVisitor"]),
                            GoalsDifference = Convert.ToInt32(reader["SumHome"]) - Convert.ToInt32(reader["SumVisitor"]),
                            Won = Convert.ToInt32(reader["TWon"]),
                            Draw = Convert.ToInt32(reader["TDraw"]),
                            Lost = Convert.ToInt32(reader["TLost"])
                        });
                    }
                }
            }
            return Standings;
        }
    }
}
