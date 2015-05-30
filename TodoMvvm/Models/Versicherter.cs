using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ZeusMobile.Models
{
    public class Versicherter
    {
        [MaxLength(20)]
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Subject))]
        public int SubjektId { get; set; }
        
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Police> Policen { get; set; }
        
        [MaxLength(20)]
        public int VersichertenNr { get; set; }

    }
}
