using System;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ZeusMobile.Models
{
    public class Schaden
    {
        public enum EnumStatus
        {
            Gemeldet = 1,
            ZurBesichtigung = 2,
            Aufgenommen = 3,
            Beurteilt = 4,
            Ausbezahlt = 5,
            Abgeschlossen = 9
        }

        public enum EnumPrioritaet
        {
            Sofort = 1,
            Dringend = 2,
            Normal = 3
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public SchadenProtokoll SchadenProtokoll { get; set; }

        [ForeignKey(typeof(Police))]
        public int PoliceId { get; set; }

        [MaxLength(100)]
        public string Beschreibung { get; set; }

        [MaxLength(50)]
        public string Strasse { get; set; }

        [MaxLength(10)]
        public int Hausnr { get; set; }

        [MaxLength(10)]
        public string HausNrZusatz { get; set; }

        [MaxLength(3)]
        public string Land { get; set; }

        [MaxLength(6)]
        public string Plz { get; set; }

        [MaxLength(50)]
        public string Ort { get; set; }

        [MaxLength(100)]
        public string Gemeinde { get; set; }

        [MaxLength(10)]
        public int Parzelle { get; set; }

        [MaxLength(10)]
        public int GebaeudeNummer { get; set; }

        public EnumPrioritaet Prioritaet { get; set; }

        public DateTime Eintrittsdatum { get; set; }

        public DateTime Meldedatum { get; set; }

        public EnumStatus Status { get; set; }

        [Ignore]
        public String SchadenListeText
        {
            get
            {
                var listenText = Beschreibung;
                if (!string.IsNullOrEmpty(Strasse))
                {
                    listenText += ", " + Strasse;
                }
                if (!string.IsNullOrEmpty(Hausnr.ToString()))
                {
                    listenText += " " + Hausnr;
                }
                if (!string.IsNullOrEmpty(HausNrZusatz))
                {
                    listenText += " " + HausNrZusatz;
                }
                return listenText;
            }
        }
    }
}