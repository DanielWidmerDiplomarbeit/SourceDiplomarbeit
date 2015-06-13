using System;
using System.Globalization;
using ZeusMobile.Models;

namespace ZeusMobile.ViewModels
{
    class VersicherteViewModel : BaseViewModel
    {

        public VersicherteViewModel(Versicherter versicherter, Person person)
        {
            Versicherter = versicherter;
            Person = person;

            Aufbereiten();
        }

        private void Aufbereiten()
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

