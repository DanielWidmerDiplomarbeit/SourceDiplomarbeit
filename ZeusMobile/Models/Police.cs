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
    public class Police
    {
        public enum EnumAbteilung
        {
            Monopol = 1,
            Markt = 2
        }

        public enum EnumKategorie
        {
            Gebaeude = 1,
            Land = 2
        }

        public enum EnumBranche
        {
            Elementar = 1,
            Sach = 2
        }

        public enum EnumDeckung
        {
            Voll = 1,
            Teilweise = 2
        }


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Objekt> Versicherungsobjekte { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Schaden> Schaeden { get; set; }

        [ForeignKey(typeof(Versicherter))]
        public int VersicherterId { get; set; }
        
        [MaxLength(15), NotNull]
        public string PolicenNr { get; set; }

        [MaxLength(20), NotNull]
        public string Bezeichnung { get; set; }

        public EnumAbteilung Abteilung { get; set; }
        
        public EnumKategorie Kategorie { get; set; }   

        public EnumBranche Branche { get; set; }

        public EnumDeckung Deckung { get; set; }

        [Ignore]
        public string PoliceListeText
        {
            get
            {
                var listenText = Bezeichnung;
                if (!string.IsNullOrEmpty(PolicenNr))
                {
                    listenText += ", " + PolicenNr;
                }
               return listenText;
            }
        }

    }
}