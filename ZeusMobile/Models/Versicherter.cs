// <copyright company="ZHAW">
// Copyright (c) 2015 All Right Reserved
// </copyright>
// <author>Daniel Widmer</author>
// <date>30.06.2015</date>

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

        [ForeignKey(typeof(Person))]
        public int SubjektId { get; set; }
        
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Police> Policen { get; set; }
        
        [MaxLength(20)]
        public int VersichertenNr { get; set; }

        public DateTime KundeSeit { get; set; }

    }
}
