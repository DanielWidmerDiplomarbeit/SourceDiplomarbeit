using System;
using System.Collections.Generic;
using System.Linq;
using ZeusMobile.Data;
using ZeusMobile.Models;

namespace ZeusMobile.Data
{
    public class DemoData
    {
        public List<Subject> Subjects { get; private set; }
        public List<SchadensExperte> SchadensExperten { get; private set; }
        public List<Police> Polices { get; private set; }
        public List<Schaden> Schaeden { get; private set; }
        public List<Versicherter> Versicherte { get; private set; }

        public void BuildDemoData(DataBase database)
        {
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
                    var experte = new SchadensExperte
                    {
                        ExpertenNr = expertenNr++,
                        SubjektId = subject.Id
                    };

                    subject.SchadensExperten = new SchadensExperte();
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
                    var police = Polices.FirstOrDefault(x => x.PolicenNr == "88");
                    police.VersicherterId = versicherter.Id;
                    versicherter.Policen = new List<Police>();
                    versicherter.Policen.Add(police);
                }

                if (versicherter.VersichertenNr == 3216)
                {
                    var police = Polices.FirstOrDefault(x => x.PolicenNr == "99");
                    police.VersicherterId = versicherter.Id;
                    versicherter.Policen = new List<Police>();
                    versicherter.Policen.Add(police);
                }
            }

            database.InsertOrReplaceAllVersicherteWithChildren(Versicherte);


            Polices = database.getPolicen();

            var versicherungsobjekte = DemoVersicherungsObjekte();

            foreach (var police in Polices)
            {

                if (police.PolicenNr.Equals("88"))
                {
                    var objekt1 = versicherungsobjekte.FirstOrDefault(x => x.ObjektId == "11");
                    var objekt2 = versicherungsobjekte.FirstOrDefault(x => x.ObjektId == "22");
                    objekt1.PoliceId = police.Id;
                    objekt2.PoliceId = police.Id;
                    police.Versicherungsobjekte = new List<Versicherungsobjekt>();
                    police.Versicherungsobjekte.Add(objekt1);
                    police.Versicherungsobjekte.Add(objekt2);

                    var schaden1 = Schaeden.FirstOrDefault(x => x.GebaeudeNummer == 1711);
                    var schaden2 = Schaeden.FirstOrDefault(x => x.GebaeudeNummer == 1718);
                    schaden1.PoliceId = police.Id;
                    schaden2.PoliceId = police.Id;
                    schaden1.SchadenProtokoll = new SchadenProtokoll();

                    police.Schaeden = new List<Schaden>();
                    police.Schaeden.Add(schaden1);
                    police.Schaeden.Add(schaden2);

                }
                if (police.PolicenNr.Equals("99"))
                {
                    var objekt3 = versicherungsobjekte.FirstOrDefault(x => x.ObjektId == "33");
                    objekt3.PoliceId = police.Id;
                    police.Versicherungsobjekte = new List<Versicherungsobjekt>();
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
                    schaden.SchadenProtokoll = new SchadenProtokoll();
                    var protokoll = DemoSchadenProtokoll().FirstOrDefault(x => x.ProtokollNr == 1);
                    protokoll.SchadenId = schaden.Id;
                }

                if (schaden.Id == 3)
                {
                    schaden.SchadenProtokoll = new SchadenProtokoll();
                    var protokoll = DemoSchadenProtokoll().FirstOrDefault(x => x.ProtokollNr == 2);
                    protokoll.SchadenId = schaden.Id;
                }
            }

            database.InsertOrReplaceAllSchaedenWithChildren(Schaeden);

        }


        private List<Police> DemoPolicen()
        {
            var policen = new List<Police>
            {
                new Police { PolicenNr = "88", Bezeichnung = "Police EFH" , Kategorie = Police.EnumKategorie.Gebaeude , Abteilung = Police.EnumAbteilung.Monopol},
                new Police { PolicenNr = "99", Bezeichnung = "Police Ferienwohnung", Kategorie = Police.EnumKategorie.Gebaeude, Abteilung = Police.EnumAbteilung.Monopol},
            };
            return policen;
        }

        private List<Versicherungsobjekt> DemoVersicherungsObjekte()
        {
            var objekte = new List<Versicherungsobjekt>
            {
                new Versicherungsobjekt { ObjektId = "11", Bezeichnung="Einfamilienhaus", Bauart = Versicherungsobjekt.enumBauart.Voll, Hydrant ="1" },
                new Versicherungsobjekt { ObjektId = "22", Bezeichnung="Garage", Bauart = Versicherungsobjekt.enumBauart.Voll, Hydrant ="1" },
                new Versicherungsobjekt { ObjektId = "33", Bezeichnung="Ferienhaus", Bauart = Versicherungsobjekt.enumBauart.Voll, Hydrant ="2" }
            };
            return objekte;
        }


        private List<Schaden> DemoSchadensfaelle()
        {
            var Schaeden = new List<Schaden> {

				new Schaden { GebaeudeNummer = 1711, Eintrittsdatum = DateTime.Parse("01.07.2015"), Meldedatum = DateTime.Parse("02.07.2015"), Gemeinde = "Netstal", Strasse = "Obergasse", Hausnr = 1, HausNrZusatz = "A", Parzelle = 576, Land = "CH", PLZ = "8754", Ort = "Netstal"},
				new Schaden { GebaeudeNummer = 1718, Eintrittsdatum = DateTime.Parse("01.08.2015"), Meldedatum = DateTime.Parse("02.08.2015"), Gemeinde = "Netstal", Strasse = "Obergasse", Hausnr = 1, HausNrZusatz = "A", Parzelle = 416, Land = "CH", PLZ = "8754", Ort = "Netstal"},
				new Schaden { GebaeudeNummer = 1719, Eintrittsdatum = DateTime.Parse("01.08.2015"), Meldedatum = DateTime.Parse("02.08.2015"), Gemeinde = "Netstal", Strasse = "Am Bergli", Hausnr = 323, HausNrZusatz = null, Parzelle = 256, Land = "CH", PLZ = "8754", Ort = "Netstal"}
         };
            return Schaeden;
        }

        private List<SchadenProtokoll> DemoSchadenProtokoll()
        {
            var schadenProtokollList = new List<SchadenProtokoll> {
            new SchadenProtokoll { ProtokollNr = 1,  Beschreibung = "Lawine",Approxsumme = 1200000, Selbstbehalt = 500},
            new SchadenProtokoll { ProtokollNr = 2, Beschreibung = "Gleiche Lawine", Approxsumme = 500000, Selbstbehalt = 600},
         };
            return schadenProtokollList;
        }

        private List<Subject> DemoSubjects()
        {
            var subjects = new List<Subject> {
                new Subject {Name = "Kunde Adam", Rolle = "Kunde" },
                new Subject {Name = "Kunde Bruno", Rolle = "Kunde" },
                new Subject {Name = "Expertin Eva", Rolle = "Experte" },
                new Subject {Name = "Experte Zorro", Rolle = "Experte" }
            };
            return subjects;
        }

    }

}

