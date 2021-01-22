using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text.RegularExpressions;
using BuildIt.Data.Sqlite.Common;

namespace FussballManagerLogic
{
    public class DbConnector
    {
        public List<string> FileContent { get; set; } = new List<string>();
        public List<string> FirstNames { get; set; } = new List<string>();
        public List<string> LastNames { get; set; } = new List<string>();
        public List<string> Names { get; set; } = new List<string>();

        #region Constructor

        public DbConnector()
        {
            FileContent = ReadTextFile();
            
        }

        #endregion

        public void ReadAndFill()
        {
            ReadTextFile();

            for (int i = 0; i < FileContent.Count; i++)
            {
                // TODO:Datenbank bekommt keine einträge (#Methoden laufen ohne Fehler durch)
                //WriteNames(NamensArt.FirstName, FileContent[i]);
                //WriteNames(NamensArt.LastName, FileContent[i]);
                WriteNamesToDb(NamensArt.FirstName, FileContent[i]);
                WriteNamesToDb(NamensArt.LastName, FileContent[i]);
            }
        }


        
        private void WriteNames(Enum pNamen, string pItem)
        {
            SQLiteConnectionStringBuilder builder = new();
            builder.DataSource = "fmNames.db";
            builder.FailIfMissing = true;
            builder.Version = 3;

            using SQLiteConnection connection = new SQLiteConnection(builder.ToString());
            connection.Open();
            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = pNamen switch
            {
                NamensArt.FirstName => "Insert into firstNames (FirstName) Values ( @name)",
                NamensArt.LastName => "Insert into lastNames (lastName) Values ( @name)",
                NamensArt.FullName => "Insert into firstNames (FirstName) Values ( @name)",
                _ => ""
            };
            
            command.Parameters.AddWithValue("name", pItem);
            command.ExecuteNonQuery();
        }


        private void WriteNamesToDb(Enum pNamen, string pItem)
        {
            SQLiteConnectionStringBuilder builder = new();
            builder.DataSource = "fmNames";
            builder.Version = 3;

            using SQLiteConnection connection = new SQLiteConnection(builder.ToString());
            connection.Open();

            SQLiteCommand command = connection.CreateCommand();
            SQLiteTransaction trans = connection.BeginTransaction();
            command.Transaction = trans;
            for (int i = 1; i <= FirstNames.Count; i++)
            {
                try
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("name", FirstNames[i - 1]);
                    // SQL Query dem Objekt übergeben
                    command.CommandText = pNamen switch
                    {
                        NamensArt.FirstName => "Insert into firstNames (FirstName) Values ( @name)",
                        NamensArt.LastName => "Insert into lastNames (lastName) Values ( @name)",
                        NamensArt.FullName => "Insert into firstNames (FirstName) Values ( @name)",
                        _ => ""
                    };

                    command.ExecuteNonQuery();
                }
                catch
                {
                    return;
                }
            }

            trans.Commit();
        }

        #region Text vorbehandeln

        private List<string> ReadTextFile()
        {
            string row;
            using (var reader = new StreamReader(@"RandomNames.txt"))
            {
                while ((row = (reader.ReadLine())) != null)
                {
                    FileContent.Add(row);
                }
            }

            FileContent = FormatNames(NamensArt.FullName);
            FirstNames = FormatNames(NamensArt.FirstName);
            LastNames = FormatNames(NamensArt.LastName);

            return FileContent;
        }


        private List<string> FormatNames(Enum pNamen)
        {
            string pattern;
            switch (pNamen)
            {
                case NamensArt.FirstName:
                    pattern = @"([A-Za-z]+)";
                    return MatchesOfPattern(pattern, FirstNames = new List<string>(), 0);

                case NamensArt.LastName:
                    pattern = @"(_[A-Za-z]+)";
                    return MatchesOfPattern(pattern, LastNames = new List<string>(), 1);

                default:
                    return FileContent;
            }

        }


        private List<string> MatchesOfPattern(string pPattern, List<string> pNameList, int pStartIndex)
        {
            System.Text.RegularExpressions.Match match;

            foreach (string item in FileContent)
            {
                match = Regex.Match(item, pPattern);
                pNameList.Add(match.Value.Substring(pStartIndex, match.Value.Length - pStartIndex));
            }

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