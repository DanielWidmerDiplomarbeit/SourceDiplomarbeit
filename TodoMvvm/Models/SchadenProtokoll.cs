using System;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ZeusMobile.Models
{
    public class SchadenProtokoll
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Schaden))]
        public int SchadenId { get; set; }

        public int ProtokollNr { get; set; }

        [MaxLength(4000)]
        public string Beschreibung { get; set; }
        
        [MaxLength(4000)]
        public string InterneNotiz { get; set; }

        [MaxLength(100)]
        public string Ursache { get; set; }

        [MaxLength(4000)]
        public string UrsachenBeschreibung { get; set; }

        public decimal Approxsumme { get; set; }
        public decimal Selbstbehalt { get; set; }
        public decimal Minimum { get; set; }
        public decimal Maximum { get; set; }
        public DateTime LetzteBearbeitung { get; set; }
    }
}