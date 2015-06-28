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
    public class Person
    {
        [MaxLength(20)]
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Versicherter Versicherte { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Sachbearbeiter SchadensExperten { get; set; }

        [MaxLength(20)]
        public string Rolle { get; set; }
        
        [MaxLength(50)]
        public string Name { get; set; }        

        [MaxLength(50)]
        public string Vorname { get; set; }
        
        [MaxLength(50)]
        public string Strasse { get; set; }    
        
        [MaxLength(15)]
        public string Nr { get; set; }

        [MaxLength(6)]
        public string Plz { get; set; }

        [MaxLength(50)]
        public string Ort { get; set; }

        [Ignore]
        public string PersonListeText
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