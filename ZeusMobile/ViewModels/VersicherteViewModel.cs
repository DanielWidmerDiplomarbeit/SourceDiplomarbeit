// <copyright company="ZHAW">
// Copyright (c) 2015 All Right Reserved
// </copyright>
// <author>Daniel Widmer</author>
// <date>30.06.2015</date>

using System;
using System.Globalization;
using ZeusMobile.BaseClassesGD;
using ZeusMobile.Models;

namespace ZeusMobile.ViewModels
{
    class VersicherteViewModel : BaseViewModel
    {

        public VersicherteViewModel(Versicherter versicherter, Person person)
        {
            Versicherter = versicherter;
            Person = person;

            AnzeigeAufbereiten();
        }

        private void AnzeigeAufbereiten()
        {
            if ( Versicherter != null && Versicherter.KundeSeit > DateTime.MinValue)
            {
                var ci = new CultureInfo("de-DE");
                KundeSeitAnzeige = Versicherter.KundeSeit.Date.ToString("d", ci);
            }
            else
            {
                KundeSeitAnzeige = string.Empty;
            }
        }

        public Person Person { get; private set; }
        public Versicherter Versicherter { get; private set; }

        public string KundeSeitAnzeige { get; private set; }
    }
}

