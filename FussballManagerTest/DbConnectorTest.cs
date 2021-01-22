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
            db.ReadAndFill();
            Assert.IsTrue(db.FileContent != null);
        }

        [TestMethod]
        public void CheckNameFormat()
        {
            DbConnector db = new();
            db.ReadAndFill();
            Assert.IsFalse(db.FileContent.Contains("_"));
        }

        [TestMethod]
        public void ReadAndFillTest()
        {
            DbConnector db = new();
            db.ReadAndFill();

            Assert.IsTrue(db.FileContent.Count > 0);
        }
    }
}