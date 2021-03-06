﻿// <copyright company="ZHAW">
// Copyright (c) 2015 All Right Reserved
// </copyright>
// <author>Daniel Widmer</author>
// <date>30.06.2015</date>
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ZeusMobile.Models
{



    public class Objekt
    {

        public enum EnumBauart
        {
            Voll = 1,
            Teilweise = 2
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        [ForeignKey(typeof(Police))]
        public int PoliceId { get; set; }

        [ForeignKey(typeof(Protokoll))]
        public int SchadenProtokollId { get; set; }
        
        [MaxLength(10)]
        [Unique]
        public string ObjektId { get; set; }

        [MaxLength(50)]
        public string Bezeichnung { get; set; }
        
        public string Hydrant { get; set; }
        
        public EnumBauart Bauart { get; set; }

        [Ignore]
        public string ObjektListeText
        {
            get
            {
                var listenText = Bezeichnung;
                if (!string.IsNullOrEmpty(ObjektId))
                {
                    listenText += ", " + ObjektId;
                }
                return listenText;
            }
        }
    }
}