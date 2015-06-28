// <copyright company="ZHAW">
// Copyright (c) 2015 All Right Reserved
// </copyright>
// <author>Daniel Widmer</author>
// <date>30.06.2015</date>
using System;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ZeusMobile.Models
{
    public class Schaden
    {
        public enum EnumStatus
        {
            Gemeldet = 1,
            ZurBesichtigung = 2,
            Aufgenommen = 3,
            Beurteilt = 4,
            Ausbezahlt = 5,
            Abgeschlossen = 9
        }

        public enum EnumPrioritaet
        {
            Sofort = 1,
            Dringend = 2,
            Normal = 3
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Protokoll Protokoll { get; set; }

        [ForeignKey(typeof(Police))]
        public int PoliceId { get; set; }

        [MaxLength(100)]
        public string Beschreibung { get; set; }

        [MaxLength(50)]
        public string Strasse { get; set; }

        [MaxLength(10)]
        public string Hausnr { get; set; }

        [MaxLength(3)]
        public string Land { get; set; }

        [MaxLength(6)]
        public string Plz { get; set; }

        [MaxLength(50)]
        public string Ort { get; set; }

        [MaxLength(100)]
        public string Gemeinde { get; set; }

        [MaxLength(10)]
        public int Parzelle { get; set; }

        [MaxLength(10)]
        public int GebaeudeNummer { get; set; }

        public EnumPrioritaet Prioritaet { get; set; }

        public DateTime Eintrittsdatum { get; set; }

        public DateTime Meldedatum { get; set; }

        public DateTime LetzteMutation { get; set; }

        public EnumStatus Status { get; set; }

        [Ignore]
        public string MutationsDatumText
        {
            get
            {
                if (LetzteMutation.Equals(DateTime.MinValue))
                {
                    return string.Empty;
                }
                return LetzteMutation.ToString("dd.MM.yyyy HH:mm:ss ");
            }
        }

        [Ignore]
        public String SchadenOrtListeText
        {
            get
            {
                string listenText = string.Empty;
                if (!string.IsNullOrEmpty(Strasse))
                {
                    listenText += Strasse;
                }
                if (!string.IsNullOrEmpty(Hausnr))
                {
                    listenText += " " + Hausnr;
                }
                if (!string.IsNullOrEmpty(Plz))
                {
                    listenText += " " + Plz;
                }
                if (!string.IsNullOrEmpty(Ort))
                {
                    listenText += " " + Ort;
                }

                return listenText;
            }
        }

        [Ignore]
        public String SchadenListeText
        {
            get
            {
                return Beschreibung;
            }
        }
    }
}