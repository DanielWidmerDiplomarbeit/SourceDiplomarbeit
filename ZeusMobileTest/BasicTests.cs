using System;
using CoreFoundation;
using NUnit.Framework;
using System.IO;
using SQLiteNetExtensions.Extensions;
using ZeusMobile;
using System.Linq;
using ZeusMobile.Data;
using System.Collections.Generic;
using ZeusMobile.Models;

namespace ZeusMobileTest
{
    [TestFixture]
    public class BasicTests
    {

        [Test]
        public void buildDemoDatabase()
        {
            const string sqliteFilename = "TestDbLite.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFilename);

            if (File.Exists(path))
            {
                const string save = @"/Users/dani/Dropbox/ZHAW/Diplomarbeit/TestDb";

                var dropBoxFile = Path.Combine(save, sqliteFilename);
                if (File.Exists(dropBoxFile))
                {
                    File.Delete(dropBoxFile);
                }
                try
                {
                    File.Copy(path, dropBoxFile);
                }
                catch (Exception)
                {
                    // do nothing
                }

                File.Delete(path);
            }

            var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);

            AppConn.SetDatabaseConnection(conn);
            var database = AppConn.TestDataBase;

            var demoData = new DemoData();
            demoData.BuildDemoData(database);

            Assert.AreEqual(4, database.GetSubjekte().ToList().Count());
            Assert.AreEqual(2, database.GetVersicherte().ToList().Count());
            Assert.AreEqual(2, database.GetSchadensExperten().ToList().Count());
            Assert.AreEqual(3, database.GetSchaeden().ToList().Count());
            Assert.AreEqual(2, database.getPolicen().ToList().Count());
            Assert.AreEqual(2, database.GetSchadenProtokolle().ToList().Count());
        }

        [Test]
        public void Test_SaveSchaden()
        {
            var database = AppConn.TestDataBase;
            var schaden = database.GetSchaden(1);
            Assert.AreEqual("Wasserschaden Keller", schaden.Beschreibung);
            schaden.Beschreibung = "Wasserschaden Estrich";
            database.SaveSchaden(schaden);
            schaden = database.GetSchaden(1);
            Assert.AreEqual("Wasserschaden Estrich", schaden.Beschreibung);
        }

        [Test]
        public void Test_InsertProtokoll()
        {
            var database = AppConn.TestDataBase;
            var schaden = database.GetSchaden(1);

            var protokoll = new Protokoll
            {
                Beschreibung = "Test Neues Schadenprotokoll",
                SchadenId = schaden.Id,
                Approxsumme = 500000,
                Selbstbehalt = 5000,
                Minimum = 400000,
                Maximum = 60000,
                InterneNotiz = "Ich bin eine interne Notiz ääää ööö üüü ÄÄÖÖÜÜ",
                Ursache = "selber schuld",
                UrsachenBeschreibung = "Er ist wirklich selber schuld",
                ProtokollNr = 4711,
                LetzteBearbeitung = DateTime.Now
            };

            database.SaveProtokoll(protokoll);
            database.GetProtokollByProtokollNr(4711);
            
            Assert.AreEqual("Test Neues Schadenprotokoll", protokoll.Beschreibung);
        }

        public void Test_UpdateProtokoll()
        {
            var database = AppConn.TestDataBase;
            var schaden = database.GetSchaden(1);

            var protokoll = new Protokoll
            {
                Beschreibung = "Test Neues Schadenprotokoll",
                SchadenId = schaden.Id,
                Approxsumme = 500000,
                Selbstbehalt = 5000,
                Minimum = 400000,
                Maximum = 60000,
                InterneNotiz = "Ich bin eine interne Notiz ääää ööö üüü ÄÄÖÖÜÜ",
                Ursache = "selber schuld",
                UrsachenBeschreibung = "Er ist wirklich selber schuld",
                ProtokollNr = 4712,
                LetzteBearbeitung = DateTime.Now
            };

            database.SaveProtokoll(protokoll);
            var neuesProtokoll = database.GetProtokollByProtokollNr(4712);
            Assert.AreEqual(500000,neuesProtokoll.Approxsumme);
            neuesProtokoll.Approxsumme = 555555;
            database.SaveProtokoll(neuesProtokoll);
            var mutiertesProtokoll = database.GetProtokollByProtokollNr(4712);

            Assert.AreEqual(555555, mutiertesProtokoll.Approxsumme);
        }
    }

    public static class AppConn
    {
        static SQLite.Net.SQLiteConnection _conn;
        static DataBase _database;
        public static void SetDatabaseConnection(SQLite.Net.SQLiteConnection connection)
        {
            _conn = connection;
            _database = new DataBase(_conn);
        }
        public static DataBase TestDataBase
        {
            get { return _database; }
        }
    }
}
