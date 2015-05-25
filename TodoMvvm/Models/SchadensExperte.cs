using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ZeusMobile.Models
{
    public class SchadensExperte
    {
        [MaxLength(20)]
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Subject))]
        public int SubjektId { get; set; }

        [ManyToMany(typeof(Subject))]
        public List<Schaden> Schaeden { get; set; }
        
        [MaxLength(20)]
        public int ExpertenNr { get; set; }
    }
}