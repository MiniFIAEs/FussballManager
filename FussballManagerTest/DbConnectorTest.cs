using System.Data.SQLite;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FussballManagerLogic;

namespace FussballManagerTest
{
    [TestClass]
    public class DbConnectorTest
    {
        [TestMethod]
        public void CreateDbConnector()
        {
            DbConnector db = new();
            Assert.IsTrue(db != null);
        }

        [TestMethod]
        public void ReadTextFile()
        {
            DbConnector db = new();
            Assert.IsTrue(File.Exists("RandomNames.txt"));
            db.Save();
            Assert.IsTrue(db.FirstNames != null);
            Assert.IsTrue(db.FileContent.Count == 1000);
            Assert.IsTrue(db.FirstNames.Count == 1000);
            Assert.IsTrue(db.LastNames.Count > 0);
            Assert.IsTrue(db.LastNames.Count == db.FirstNames.Count);
            Assert.IsTrue(db.FileContent.Count == db.FirstNames.Count);
        }

        [TestMethod]
        public void CheckNameFormat()
        {
            DbConnector db = new();
            db.Save();
            Assert.IsTrue(db.FileContent.Count == 1000);
            Assert.IsFalse(db.FileContent.Contains("_"));
        }

        [TestMethod]
        public void FillConnentor()
        {
            DbConnector db = new();
            db.Save();

            Assert.IsTrue(db.FileContent.Count > 0);
            Assert.IsTrue(db.FirstNames != null);
            Assert.IsTrue(db.LastNames != null);
            Assert.IsFalse(db.FirstNames.Count == 0);
            Assert.IsTrue(db.LastNames.Count == db.FileContent.Count);
            Assert.IsTrue(db.FirstNames.Count == 1000);
            Assert.IsFalse(db.FirstNames.Contains("_"));
            Assert.IsTrue(db.FirstNames[0] == "Kylen");
            Assert.IsTrue(db.LastNames[0] == "Jett");
        }

        

        [TestMethod]
        public void BuilderDb()
        {
            var builder = new SQLiteConnectionStringBuilder();
            builder.DataSource= "fmNames.db";
            builder.Version = 3;
            
            Assert.IsFalse(builder == null);
            Assert.IsTrue(builder.DataSource == "fmNames.db");
            Assert.IsTrue(builder.Version == 3);

        }
    }
}