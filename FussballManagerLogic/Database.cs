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
        public static bool SaveTeamToDatabase(Team team)
        {
            SQLiteConnectionStringBuilder builder = new();
            builder.Version = 3;
            builder.DataSource = "GameDatabase.db";
            if (!File.Exists(builder.DataSource))
            {
                using (SQLiteConnection connection = new(builder.ToString()))
                {
                    connection.Open();
                    SQLiteCommand command = connection.CreateCommand();

                    command.CommandText = "create table Teams (ID integer not null primary key, Name varchar(25) not null unique)";
                    command.ExecuteNonQuery();

                    command.CommandText = "create table Players (ID integer not null primary key, Name varchar(25) not null unique, TeamID integer not null, Speed integer not null, Precision integer not null, Duel integer not null, Position integer not null)";
                    command.ExecuteNonQuery();

                }
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
    }
}
