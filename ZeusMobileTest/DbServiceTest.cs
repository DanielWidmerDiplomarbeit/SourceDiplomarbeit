// <copyright company="ZHAW">
// Copyright (c) 2015 All Right Reserved
// </copyright>
// <author>Daniel Widmer</author>
// <date>30.06.2015</date>
using System;
using NUnit.Framework;
using System.IO;
using ZeusMobile.Data;
using ZeusMobile.Models;
using ZeusMobile.Services;

namespace ZeusMobileTest
{
    [TestFixture]
    public class BasicTests
    {

        [Test]
        public void Test_1_1_1_SucheFindetKeineFaelle()
        {
            var zeusDbService = new ZeusDbService(AppConn.TestDataBase);
            var schadensAuswahlListe = zeusDbService.ReadSchadenListe("findenix", false);
            Assert.AreEqual(0, schadensAuswahlListe.Count);
        }

        [Test]
        public void Test_1_1_2_SucheFindet3Faelle()
        {
            var zeusDbService = new ZeusDbService(AppConn.TestDataBase);
            var schadensAuswahlListe = zeusDbService.ReadSchadenListe(string.Empty, false);
            Assert.AreEqual(3, schadensAuswahlListe.Count);
        }

        [Test]
        public void Test_1_2_1_AlleErledigtKeineGefunden()
        {
            var zeusDbService = new ZeusDbService(AppConn.TestDataBase);
            var schadensAuswahlListe = zeusDbService.ReadSchadenListe("findenix", true);
            Assert.AreEqual(0, schadensAuswahlListe.Count);
        }

        [Test]
        public void Test_1_2_2_DreiVonFuenfFaellenErledigt()
        {
            var zeusDbService = new ZeusDbService(AppConn.TestDataBase);
            var schadensAuswahlListe = zeusDbService.ReadSchadenListe(string.Empty, false);
            Assert.AreEqual(3, schadensAuswahlListe.Count);
        }

        [Test]
        public void Test_1_2_3_KeinFallErledigtKeinerGefunden()
        {
            var zeusDbService = new ZeusDbService(AppConn.TestDataBase);
            var schadensAuswahlListe = zeusDbService.ReadSchadenListe("findenix", true);
            Assert.AreEqual(0, schadensAuswahlListe.Count);
        }

        [Test]
        public void Test_1_3_1_ErweiterteSucheSchadenOrtKorrekt()
        {
            var zeusDbService = new ZeusDbService(AppConn.TestDataBase);
            var schadensAuswahlListe = zeusDbService.ReadSchadenListe("Wasser", true);
            Assert.AreEqual(2, schadensAuswahlListe.Count);
        }

        [Test]
        public void Test_2_2_1_NeuesProtokollAnlegen()
        {
            var zeusDbService = new ZeusDbService(AppConn.TestDataBase);
            var schaden = zeusDbService.ReadSchaden(1);
            var altesProtokoll = zeusDbService.ReadProtokoll(1);
            zeusDbService.DeleteProtokoll(altesProtokoll);

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
            protokoll = zeusDbService.ReadProtokoll(schaden.Id);

            Assert.AreEqual("Test Neues Schadenprotokoll", protokoll.Beschreibung);
        }

        [Test]
        public void Test_2_2_2_BestehendesProtokollStattNeuesZeigen()
        {
            var zeusDbService = new ZeusDbService(AppConn.TestDataBase);
            var schaden = zeusDbService.ReadSchaden(1);
            var altesProtokoll = zeusDbService.ReadProtokoll(1);
            zeusDbService.DeleteProtokoll(altesProtokoll);

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
            protokoll = zeusDbService.ReadProtokoll(schaden.Id);

            Assert.AreEqual("Test Neues Schadenprotokoll", protokoll.Beschreibung);
        }

        [Test]
        public void Test_2_3_1_NeuesProtokoll()
        {
            var zeusDbService = new ZeusDbService(AppConn.TestDataBase);
            var schaden = zeusDbService.ReadSchaden(1);
            var altesProtokoll = zeusDbService.ReadProtokoll(1);
            zeusDbService.DeleteProtokoll(altesProtokoll);

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
            protokoll = zeusDbService.ReadProtokoll(schaden.Id);

            Assert.AreEqual("Test Neues Schadenprotokoll", protokoll.Beschreibung);
        }

        [Test]
        public void Test_2_3_2_LesenBestehendesProtokoll()
        {
            var zeusDbService = new ZeusDbService(AppConn.TestDataBase);
            var schaden = zeusDbService.ReadSchaden(1);
            var altesProtokoll = zeusDbService.ReadProtokoll(1);
            zeusDbService.DeleteProtokoll(altesProtokoll);

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
        public void Test_2_3_3_UpdateBestehendesProtokoll()
        {
            var zeusDbService = new ZeusDbService(AppConn.TestDataBase);
            var schaden = zeusDbService.ReadSchaden(1);
            var altesProtokoll = zeusDbService.ReadProtokoll(1);
            zeusDbService.DeleteProtokoll(altesProtokoll);

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
            protokoll = zeusDbService.ReadProtokoll(schaden.Id);

            Assert.AreEqual("Test Neues Schadenprotokoll", protokoll.Beschreibung);
        }

        [Test]
        public void Test_2_3_4_DeleteBestehendesProtokoll()
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
                catch (IOException)
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
        }
    }

}
