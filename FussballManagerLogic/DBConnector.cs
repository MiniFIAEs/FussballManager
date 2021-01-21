using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.SQLite;
using System.IO;
using System.Text.RegularExpressions;

namespace FussballManagerLogic
{
    public class DBConnector
    {
        private static string row;
        List<string> fileContent = new List<string>();
        List<string> names = new List<string>();
        List<string> foreNames = new List<string>();


        public DBConnector()
        {
            readTextFile();
            writeForeNames();
            writeNames();
        }

        private void writeNames()
        {
            SQLiteConnectionStringBuilder builder = new();
            builder.DataSource = "names.db";
            builder.Version = 3;

            using (SQLiteConnection connection = new SQLiteConnection(builder.ToString()))
            {
                connection.Open();
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "Insert into names (foreName) Values (@foreName)";
                
                foreach (var item in foreNames)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("foreName", item);
                    command.ExecuteNonQuery();
                }
            }
        }


        private void writeForeNames()
        {
            SQLiteConnectionStringBuilder builder = new();
            builder.DataSource = "names.db";
            builder.FailIfMissing = true;
            builder.Version = 3;

            using (SQLiteConnection connection = new SQLiteConnection(builder.ToString()))
            {
                
                connection.Open();
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "Insert into names (name) Values (@name)";
                //ich schau wo was wie passiert
                foreach (var item in foreNames)
                {//daten sind nicht korrekt vorformatiert 1000stck namen sinds also hat er erst vor dann namen...

                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("name", item);
                    command.ExecuteNonQuery();
                }
            }
        }// ich pushe nur die db. und für mein grundsystem nehm ich mir deveoper


        private void readTextFile()
        {
            using (var reader = new StreamReader(@"RandomNames.txt"))
            {
                while ((row = (reader.ReadLine())) != null)
                {
                    fileContent.AddRange(new[] {row});
                }
            }

            formatNames();
        }


        private void formatNames()
        {
            System.Text.RegularExpressions.Match match;

            string pattern = @"([A-Za-z]+)";
            MatchesOfPattern(pattern);

            pattern = @"([A-Za-z]+)";
            MatchesOfPattern(pattern);
        }


        private void MatchesOfPattern(string pattern)
        {
            System.Text.RegularExpressions.Match match;
            foreach (string item in fileContent)
            {
                pattern = @"([A-Za-z]+)";
                match = Regex.Match(item, pattern);
                foreNames.Add(match.Value.Substring(0, match.Value.Length - 1));

                pattern = @"(_[A-Za-z]+)";
                match = Regex.Match(item, pattern);
                names.Add(match.Value.Substring(1, match.Value.Length - 1));
            }
        }
    }
}