﻿// <copyright company="ZHAW">
// Copyright (c) 2015 All Right Reserved
// </copyright>
// <author>Daniel Widmer</author>
// <date>30.06.2015</date>
using System;
using System.Collections.Generic;
using System.Linq;
using ZeusMobile.Models;
using ZeusMobile.Services;

namespace ZeusMobile.Data
{
    public class DemoData
    {
        public List<Person> Subjects { get; private set; }
        public List<Sachbearbeiter> SchadensExperten { get; private set; }
        public List<Police> Polices { get; private set; }
        public List<Schaden> Schaeden { get; private set; }
        public List<Versicherter> Versicherte { get; private set; }

        public void BuildDemoData(DataBase database)
        {
            var zeusDbService = new ZeusDbService(database);
            var versichertenNr = 3215;
            var expertenNr = 15;

            Subjects = DemoSubjects();

            foreach (var subject in Subjects)
            {
                if (subject.Rolle.Equals("Kunde"))
                {
                    var versicherter = new Versicherter
                    {
                        VersichertenNr = versichertenNr++,
                        SubjektId = subject.Id,
                    };

                    subject.Versicherte = new Versicherter();
                    subject.Versicherte = versicherter;
                }

                if (subject.Rolle.Equals("Experte"))
                {
                    var experte = new Sachbearbeiter
                    {
                        ExpertenNr = expertenNr++,
                        SubjektId = subject.Id
                    };

                    subject.SchadensExperten = new Sachbearbeiter();
                    subject.SchadensExperten = experte;
                }
            }

            database.InsertOrReplaceAllSubjectsWithChildren(Subjects);

            Polices = DemoPolicen();
            Schaeden = DemoSchadensfaelle();
            Versicherte = database.GetVersicherte();

            foreach (var versicherter in Versicherte)
            {
                if (versicherter.VersichertenNr == 3215)
                {
                    var police = Polices.FirstOrDefault(x => x.PolicenNr == "77");
                    police.VersicherterId = versicherter.Id;
                    versicherter.KundeSeit = new DateTime(1995, 12, 31);
                    versicherter.Policen = new List<Police>();
                    versicherter.Policen.Add(police);
                }     
                
                if (versicherter.VersichertenNr == 3216)
                {
                    var police = Polices.FirstOrDefault(x => x.PolicenNr == "88");
                    police.VersicherterId = versicherter.Id;
                    versicherter.KundeSeit = new DateTime(1991, 12, 31);
                    versicherter.Policen = new List<Police>();
                    versicherter.Policen.Add(police);
                }

                if (versicherter.VersichertenNr == 3217)
                {
                    var police = Polices.FirstOrDefault(x => x.PolicenNr == "99");
                    police.VersicherterId = versicherter.Id;
                    versicherter.KundeSeit = new DateTime(2011, 02, 28);
                    versicherter.Policen = new List<Police>();
                    versicherter.Policen.Add(police);
                }
            }

            database.InsertOrReplaceAllVersicherteWithChildren(Versicherte);


            Polices = database.GetPolicen();

            var versicherungsobjekte = DemoVersicherungsObjekte();

            foreach (var police in Polices)
            {

                if (police.PolicenNr.Equals("77"))
                {
                    var objekt1 = versicherungsobjekte.FirstOrDefault(x => x.ObjektId == "11");
                    objekt1.PoliceId = police.Id;
                    police.Versicherungsobjekte = new List<Objekt>();
                    police.Versicherungsobjekte.Add(objekt1);

                    var schaden1 = Schaeden.FirstOrDefault(x => x.GebaeudeNummer == 1711);
                    schaden1.PoliceId = police.Id;
                    schaden1.Protokoll = new Protokoll();

                    police.Schaeden = new List<Schaden>();
                    police.Schaeden.Add(schaden1);
                }

                if (police.PolicenNr.Equals("88"))
                {
                    var objekt2 = versicherungsobjekte.FirstOrDefault(x => x.ObjektId == "22");
                    objekt2.PoliceId = police.Id;
                    police.Versicherungsobjekte = new List<Objekt>();
                    police.Versicherungsobjekte.Add(objekt2);

                    var schaden2 = Schaeden.FirstOrDefault(x => x.GebaeudeNummer == 1718);
                    schaden2.PoliceId = police.Id;
                    schaden2.Protokoll = new Protokoll();

                    police.Schaeden = new List<Schaden>();
                    police.Schaeden.Add(schaden2);

                }

                if (police.PolicenNr.Equals("99"))
                {
                    var objekt3 = versicherungsobjekte.FirstOrDefault(x => x.ObjektId == "33");
                    objekt3.PoliceId = police.Id;
                    police.Versicherungsobjekte = new List<Objekt>();
                    police.Versicherungsobjekte.Add(objekt3);

                    var schaden3 = Schaeden.FirstOrDefault(x => x.GebaeudeNummer == 1719);
                    schaden3.PoliceId = police.Id;
                    police.Schaeden = new List<Schaden>();
                    police.Schaeden.Add(schaden3);
                }
            }

            database.InsertOrReplaceAllPolicenWithChildren(Polices);

            Schaeden = database.GetSchaeden();

            foreach (var schaden in Schaeden)
            {
                if (schaden.Id == 1)
                {
                    zeusDbService.SaveProtokoll(schaden, DemoSchadenProtokoll()[0]);
                }
                if (schaden.Id == 2)
                {
                    zeusDbService.SaveProtokoll(schaden, DemoSchadenProtokoll()[1]);
                }

                if (schaden.Id == 3)
                {
                    zeusDbService.SaveProtokoll(schaden, DemoSchadenProtokoll()[2]);
                }
            }
            database.InsertOrReplaceAllSchaedenWithChildren(Schaeden);

        }


        private List<Police> DemoPolicen()
        {
            var policen = new List<Police>
            {
                new Police { PolicenNr = "77", Bezeichnung = "Police EFH" , Kategorie = Police.EnumKategorie.Gebaeude , Abteilung = Police.EnumAbteilung.Monopol, Branche = Police.EnumBranche.Elementar, Deckung = Police.EnumDeckung.Voll},
                new Police { PolicenNr = "88", Bezeichnung = "Police EFH" , Kategorie = Police.EnumKategorie.Gebaeude , Abteilung = Police.EnumAbteilung.Monopol, Branche = Police.EnumBranche.Elementar, Deckung = Police.EnumDeckung.Voll},
                new Police { PolicenNr = "99", Bezeichnung = "Police Ferienwohnung", Kategorie = Police.EnumKategorie.Gebaeude, Abteilung = Police.EnumAbteilung.Monopol, Branche = Police.EnumBranche.Elementar, Deckung = Police.EnumDeckung.Voll},
            };
            return policen;
        }

        private List<Objekt> DemoVersicherungsObjekte()
        {
            var objekte = new List<Objekt>
            {
                new Objekt { ObjektId = "11", Bezeichnung="Einfamilienhaus", Bauart = Objekt.EnumBauart.Voll, Hydrant ="1612" },
                new Objekt { ObjektId = "22", Bezeichnung="Garage", Bauart = Objekt.EnumBauart.Voll, Hydrant ="125" },
                new Objekt { ObjektId = "33", Bezeichnung="Ferienhaus", Bauart = Objekt.EnumBauart.Voll, Hydrant ="840" }
            };
            return objekte;
        }


        private List<Schaden> DemoSchadensfaelle()
        {
            var schaeden = new List<Schaden> {

				new Schaden {Status = Schaden.EnumStatus.ZurBesichtigung, Prioritaet = Schaden.EnumPrioritaet.Sofort, LetzteMutation = DateTime.Now, Beschreibung ="Wasserschaden Keller", GebaeudeNummer = 1711, Eintrittsdatum = DateTime.Parse("01.07.2015"), Meldedatum = DateTime.Parse("02.07.2015"), Gemeinde = "Netstal", Strasse = "Obergasse", Hausnr = "1 A", Parzelle = 576, Land = "CH", Plz = "8754", Ort = "Mollis"},
				new Schaden {Status = Schaden.EnumStatus.ZurBesichtigung, Prioritaet = Schaden.EnumPrioritaet.Normal, LetzteMutation = DateTime.Now, Beschreibung ="Dach eingedrückt", GebaeudeNummer = 1718, Eintrittsdatum = DateTime.Parse("01.08.2015"), Meldedatum = DateTime.Parse("02.08.2015"), Gemeinde = "Netstal", Strasse = "Obergasse", Hausnr = "1 A", Parzelle = 416, Land = "CH", Plz = "8754", Ort = "Netstal"},
				new Schaden {Status = Schaden.EnumStatus.ZurBesichtigung, Prioritaet = Schaden.EnumPrioritaet.Dringend, LetzteMutation = DateTime.Now, Beschreibung ="Wasserschaden", GebaeudeNummer = 1719, Eintrittsdatum = DateTime.Parse("01.08.2015"), Meldedatum = DateTime.Parse("02.08.2015"), Gemeinde = "Netstal", Strasse = "Am Bergli", Hausnr = "323", Parzelle = 256, Land = "CH", Plz = "8754", Ort = "Glarus"}
         };
            return schaeden;
        }

        private List<Protokoll> DemoSchadenProtokoll()
        {
            var schadenProtokollList = new List<Protokoll> {
            new Protokoll {  Beschreibung = "Keller überschwemmt", Ursache ="Dorfbach über das Ufer getreten", Approxsumme = 1200000, Selbstbehalt = 500, Minimum = 1000000, Maximum = 1500000},
            new Protokoll {  Beschreibung = "Dach eingedrückt wegen zu hoher Schneemenge", Ursache  = "Schneefälle zu stark, nasser Schnee", Approxsumme = 500000, Selbstbehalt = 600, Minimum = 400000, Maximum = 650000},
            new Protokoll {  Beschreibung = "Wasser im Keller", Ursache = "Leitung beim Nachbarn gebrochen", Approxsumme = 12000, Selbstbehalt = 600, Minimum = 8000, Maximum = 16000},
         };
            return schadenProtokollList;
        }

        private List<Person> DemoSubjects()
        {
            var subjects = new List<Person> {
                new Person {Vorname   ="Adam", Name = "Keller", Strasse = "Bachstr. 12", Plz = "8753 ", Ort = "Mollis",Rolle = "Kunde" },
                new Person {Vorname   ="Beno", Name = "Müller",Strasse = "Im Kegel 5", Plz = "8945", Ort = "Elm", Rolle = "Kunde" },
                new Person {Vorname   ="Peter", Name = "Muster",Strasse = "Im Gärtli", Plz = "8945", Ort = "Elm", Rolle = "Kunde" },
                new Person {Vorname   ="Eva", Name = "Appenzeller",Strasse = "Hauptsstr 134 ", Plz = "8800", Ort = "Glarus", Rolle = "Experte" },
                new Person {Vorname   ="Peter", Name = "Zorro", Strasse = "Bahnhofstr. 11", Plz = "8800", Ort = "Glarus", Rolle = "Experte" }
            };
            return subjects;
        }

    }

}

