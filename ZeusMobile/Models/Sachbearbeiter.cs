// <copyright company="ZHAW">
// Copyright (c) 2015 All Right Reserved
// </copyright>
// <author>Daniel Widmer</author>
// <date>30.06.2015</date>

using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ZeusMobile.Models
{
    public class Sachbearbeiter
    {
        [MaxLength(20)]
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Person))]
        public int SubjektId { get; set; }

        [ManyToMany(typeof(Person))]
        public List<Schaden> Schaeden { get; set; }
        
        [MaxLength(20)]
        public int ExpertenNr { get; set; }
    }
}