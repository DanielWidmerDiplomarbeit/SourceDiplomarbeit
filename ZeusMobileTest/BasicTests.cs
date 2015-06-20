using System;
using NUnit.Framework;
using System.IO;
using System.Linq;
using ZeusMobile.Data;
using ZeusMobile.Models;
using ZeusMobile.Services
 ;

namespace ZeusMobileTest
{
    [TestFixture]
    public class BasicTests
    {

        [SetUp]
        public void BuildDemoDatabase()
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
                catch
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
            Assert.AreEqual(2, database.GetPolicen().ToList().Count());
            Assert.AreEqual(3, database.GetSchadenProtokolle().ToList().Count());
        }

        [Test]
        public void Test_SaveSchaden()
        {
            var zeusDbService = new ZeusDbService(AppConn.TestDataBase);
            var schaden = zeusDbService.ReadSchaden(1);
            Assert.AreEqual("Wasserschaden Keller", schaden.Beschreibung);
            schaden.Beschreibung = "Wasserschaden Estrich";
            zeusDbService.SaveSchaden(schaden);
            schaden = zeusDbService.ReadSchaden(1);
            Assert.AreEqual("Wasserschaden Estrich", schaden.Beschreibung);
        }

        [Test]
        public void Test_InsertProtokoll()
        {
            var zeusDbService = new ZeusDbService(AppConn.TestDataBase);
            var schaden = zeusDbService.ReadSchaden(1);

            var protokoll = new Protokoll
            {
                Beschreibung = "Test Neues Schadenprotokoll",
                SchadenId = schaden.Id,
                Approxsumme = 500000,
                Selbstbehalt = 5000,
                Minimum = 400000,
                Maximum = 60000,
                InterneNotiz = "Ich bin eine interne Notiz mit Sonderzeichen äöü ÄÖÜ",
                Ursache = "selber schuld",
                UrsachenBeschreibung = "Er ist wirklich selber schuld",
                LetzteBearbeitung = DateTime.Now
            };
            zeusDbService.SaveProtokoll(schaden, protokoll);


            zeusDbService.SaveProtokoll(schaden, protokoll);
            protokoll = zeusDbService.ReadProtokoll(schaden.Id);

            Assert.AreEqual("Test Neues Schadenprotokoll", protokoll.Beschreibung);
        }

        [Test]
        public void Test_UpdateProtokoll()
        {
            var zeusDbService = new ZeusDbService(AppConn.TestDataBase);
            var schaden = zeusDbService.ReadSchaden(1);
            var kontrolldatum = schaden.LetzteMutation;
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
                LetzteBearbeitung = DateTime.Now
            };

            zeusDbService.SaveProtokoll(schaden, protokoll);
            var neuesProtokoll = zeusDbService.ReadProtokoll(schaden.Id);
            Assert.AreEqual(500000, neuesProtokoll.Approxsumme);
            neuesProtokoll.Approxsumme = 555555;
            zeusDbService.SaveProtokoll(schaden, neuesProtokoll);
            var mutiertesProtokoll = zeusDbService.ReadProtokoll(schaden.Id);

            Assert.AreEqual(555555, mutiertesProtokoll.Approxsumme);
            Assert.AreNotEqual(kontrolldatum, schaden.LetzteMutation);
        }

        [Test]
        public void Test_DeleteProtokoll()
        {
            var zeusDbService = new ZeusDbService(AppConn.TestDataBase);
            var schaden = zeusDbService.ReadSchaden(1);
            var kontrolldatum = schaden.LetzteMutation;
            var protokoll = new Protokoll
            {
                Beschreibung = "Test Neues Schadenprotokoll, löschen und neu Anlegen",
                SchadenId = schaden.Id,
                Approxsumme = 500000,
                Selbstbehalt = 5000,
                Minimum = 400000,
                Maximum = 60000,
                InterneNotiz = "Ich bin eine interne Notiz",
                Ursache = "Wasser",
                UrsachenBeschreibung = "Wasserschaden",
                LetzteBearbeitung = DateTime.Now
            };

            zeusDbService.SaveProtokoll(schaden, protokoll);
            zeusDbService.DeleteProtokoll(protokoll);

            var geloeschtesProtokoll = zeusDbService.ReadProtokoll(schaden.Id);
            Assert.AreEqual(null, geloeschtesProtokoll, "Nach dem Löschen darf kein Protokoll vorhanden sein");
            Assert.AreNotEqual(kontrolldatum, schaden.LetzteMutation);

            protokoll = new Protokoll
            {
                Beschreibung = "Zweites Schadenprotokoll, nach Löschen",
                SchadenId = schaden.Id,
                Approxsumme = 500000,
                Selbstbehalt = 5000,
                Minimum = 400000,
                Maximum = 60000,
                InterneNotiz = "Ich bin eine interne Notiz",
                Ursache = "Wasser",
                UrsachenBeschreibung = "Wasserschaden",
                LetzteBearbeitung = DateTime.Now
            };

            zeusDbService.SaveProtokoll(schaden, protokoll);
            var neuesProtokoll = zeusDbService.ReadProtokoll(schaden.Id);

            Assert.AreEqual("Zweites Schadenprotokoll, nach Löschen", neuesProtokoll.Beschreibung);
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
