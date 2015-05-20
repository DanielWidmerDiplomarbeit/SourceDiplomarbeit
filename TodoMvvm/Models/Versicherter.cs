using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ZeusMobile.Models
{
    public class Versicherter
    {
        [MaxLength(20)]
        [ForeignKey(typeof(Subject))]
        public int Id { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Subject Subject { get; set; }



        [MaxLength(20)]
        public int VersichertenNr { get; set; }

        [OneToMany]
        public List<Police> Polices { get; set; }

    }
}
