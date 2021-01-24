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
                    command.Parameters.AddWithValue("@TeamTwo", match.TeamOne.Name);
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
    }
}
