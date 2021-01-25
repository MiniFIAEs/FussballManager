using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using BuildIt.Data.Sqlite.Common;

namespace FussballManagerLogic
{
    public class DbConnector
    {
        public List<string> FileContent { get; set; } = new List<string>();
        public List<string> FirstNames { get; set; } = new List<string>();
        public List<string> LastNames { get; set; } = new List<string>();

        #region Constructor

        public DbConnector()
        {
            ReadTextFile();
            SplitNames();
            Save();
        }

        #endregion

        #region Copy

        public void Save()
        {
            SQLiteConnectionStringBuilder builder = new();
            builder.Version = 3;
            builder.DataSource = "fmNames.db";

            using (SQLiteConnection con = new(builder.ToString()))
            {
                con.Open();
                // check if new db-file or existing

                var command = con.CreateCommand();
                command.CommandText = "SELECT count(*) FROM sqlite_master";
                var result = command.ExecuteScalar();
                if ((Int64) result == 0)
                {
                    // tabelle neu aufbauen
                    command.CommandText = "create table FirstNames (ID int not null, firstName varchar(50) ) ";

                    command.ExecuteNonQuery();

                    command.CommandText = "create table LastNames (ID int not null, lastName varchar(50) ) ";

                    command.ExecuteNonQuery();
                }

                int row = 0;
                foreach (var item in FirstNames)
                {
                    command.CommandText = "insert into FirstNames values (@row, @fname);";
                    command.Parameters.AddWithValue("fName", item);
                    command.Parameters.AddWithValue("row", row);
                    command.ExecuteNonQuery();
                    row++;
                }

                row = 0;
                foreach (var item in LastNames)
                {
                    command.CommandText = "insert into LastNames values (@row, @lname);";
                    command.Parameters.AddWithValue("lName", item);
                    command.Parameters.AddWithValue("row", row);

                    command.ExecuteNonQuery();
                    row++;
                }
            }
        }

        public List<string> Load()
        {
            SQLiteConnectionStringBuilder builder = new();
            builder.Version = 3;
            builder.DataSource = "fmNames.db";

            List<string> resultList = new();
            using (SQLiteConnection con = new(builder.ToString()))
            {
                con.Open();
                var command = con.CreateCommand();
                // check if new db-file or existing
                command.CommandText = "SELECT count(*) FROM sqlite_master";
                var result = command.ExecuteScalar();
                if ((Int64) result != 0)
                {
                    command.CommandText = "select firstName from firstNames order by firstName;";
                    using var reader = command.ExecuteReader();

                    int count = 0;
                    while (reader.Read())
                    {
                        resultList.Add(reader.IsDBNull(0) ? "" : reader.GetString(0));
                        count++;
                    }

                    command.CommandText = "select lastName from lastNames order by lastName;";

                    for (int i = 0; i < count; i++)
                    {
                        resultList[i] += " " + (reader.IsDBNull(0) ? "" : reader.GetString(0));
                    }
                }
            }

            return resultList;
        }

        #endregion


        

        #region Text vorbehandeln

        private void ReadTextFile()
        {
            string row;
            using (var reader = new StreamReader(@"RandomNames.txt"))
            {
                while ((row = (reader.ReadLine())) != null)
                {
                    FileContent.Add(row);
                }
            }
        }

        private void SplitNames()
        {
            for (int i = 0; i < FileContent.Count; i++)
            {
                FirstNames = FormatNames(NamensArt.FirstName, FileContent[i]);
                LastNames = FormatNames(NamensArt.LastName, FileContent[i]);
            }
        }


        private List<string> FormatNames(Enum pNamen, string pItem)
        {
            string pPattern;
            switch (pNamen)
            {
                case NamensArt.FirstName:
                    pPattern = @"([A-Za-z]+)";
                    return MatchesOfPattern(pPattern, pItem, FirstNames, 0);

                case NamensArt.LastName:
                    pPattern = @"(_[A-Za-z]+)";
                    return MatchesOfPattern(pPattern, pItem, LastNames, 1);

                default:
                    return FileContent;
            }
        }


        private List<string> MatchesOfPattern(string pPattern, string pItem, List<string> pNameList, int pStartIndex)
        {
            System.Text.RegularExpressions.Match match;

            match = Regex.Match(pItem, pPattern);
            pNameList.Add(match.Value.Substring(pStartIndex, match.Value.Length - pStartIndex));

            return pNameList;
        }

        #endregion
    }

    enum NamensArt
    {
        FirstName,
        LastName,
        FullName
    }
}