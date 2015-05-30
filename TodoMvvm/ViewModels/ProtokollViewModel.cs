using System;
using ZeusMobile.Models;

namespace ZeusMobile.ViewModels
{
    internal class ProtokollViewModel : BaseViewModel
    {
        private readonly SchadenProtokoll _schadenProtokoll;

        public ProtokollViewModel(SchadenProtokoll schadenProtokoll)
        {
            _schadenProtokoll = schadenProtokoll;
        }

        public int Id
        {
            get { return _schadenProtokoll.Id; }
        }

        public string ProtokollListeText
        {
            get { return _schadenProtokoll.ProtokollListeText; }
        }

        public string Beschreibung
        {
            get { return _schadenProtokoll.Beschreibung; }
            set
            {
                if (_schadenProtokoll.Beschreibung == value)
                    return;
                _schadenProtokoll.Beschreibung = value;
                OnPropertyChanged();
            }
        }

        public string InterneNotiz
        {
            get { return _schadenProtokoll.InterneNotiz; }
            set
            {
                if (_schadenProtokoll.InterneNotiz == value)
                    return;
                _schadenProtokoll.InterneNotiz = value;
                OnPropertyChanged();
            }
        }

        public string Ursache
        {
            get { return _schadenProtokoll.Ursache; }
            set
            {
                if (_schadenProtokoll.Ursache == value)
                    return;
                _schadenProtokoll.Ursache = value;
                OnPropertyChanged();
            }
        }

        public string UrsachenBeschreibung
        {
            get { return _schadenProtokoll.UrsachenBeschreibung; }
            set
            {
                if (_schadenProtokoll.UrsachenBeschreibung == value)
                    return;
                _schadenProtokoll.UrsachenBeschreibung = value;
                OnPropertyChanged();
            }
        }


        public decimal Approxsumme
        {
            get { return _schadenProtokoll.Approxsumme; }
            set
            {
                if (_schadenProtokoll.Approxsumme == value)
                    return;
                _schadenProtokoll.Approxsumme = value;
                OnPropertyChanged();
            }
        }

        public decimal Selbstbehalt
        {
            get { return _schadenProtokoll.Selbstbehalt; }
            set
            {
                if (_schadenProtokoll.Selbstbehalt == value)
                    return;
                _schadenProtokoll.Selbstbehalt = value;
                OnPropertyChanged();
            }
        }

        public decimal Minimum
        {
            get { return _schadenProtokoll.Minimum; }
            set
            {
                if (_schadenProtokoll.Minimum == value)
                    return;
                _schadenProtokoll.Minimum = value;
                OnPropertyChanged();
            }
        }

        public decimal Maximum
        {
            get { return _schadenProtokoll.Maximum; }
            set
            {
                if (_schadenProtokoll.Maximum == value)
                    return;
                _schadenProtokoll.Maximum = value;
                OnPropertyChanged();
            }
        }

        public DateTime LetzteBearbeitung
        {
            get { return _schadenProtokoll.LetzteBearbeitung; }
            set
            {
                if (_schadenProtokoll.LetzteBearbeitung == value)
                    return;
                _schadenProtokoll.LetzteBearbeitung = value;
                OnPropertyChanged();
            }
        }
    }
}

