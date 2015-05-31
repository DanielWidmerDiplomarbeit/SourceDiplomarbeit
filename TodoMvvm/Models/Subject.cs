using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ZeusMobile.Models
{
    public class Subject
    {
        [MaxLength(20)]
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Versicherter Versicherte { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public SchadensExperte SchadensExperten { get; set; }

        [MaxLength(20)]
        public string Rolle { get; set; }
        
        [MaxLength(20)]
        public string Name { get; set; }        

        [MaxLength(20)]
        public string Vorname { get; set; }

        [Ignore]
        public string SubjectListeText
        {
            get
            {
                var listenText = Name;
                if (!string.IsNullOrEmpty(Vorname))
                {
                    listenText += ", " + Vorname;
                }
                return listenText;
            }
        }
    }
}