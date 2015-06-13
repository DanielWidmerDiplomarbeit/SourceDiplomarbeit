using System;
using ZeusMobile.Models;

namespace ZeusMobile.ViewModels
{
    internal class ProtokollViewModel : BaseViewModel
    {
        private readonly Protokoll _protokoll;

        public ProtokollViewModel(Protokoll protokoll)
        {
            _protokoll = protokoll;
        }

        public int Id
        {
            get { return _protokoll.Id; }
        }

        public string ProtokollListeText
        {
            get { return _protokoll.ProtokollListeText; }
        }

        public string Beschreibung
        {
            get { return _protokoll.Beschreibung; }
            set
            {
                if (_protokoll.Beschreibung == value)
                    return;
                _protokoll.Beschreibung = value;
                OnPropertyChanged();
            }
        }

        public string InterneNotiz
        {
            get { return _protokoll.InterneNotiz; }
            set
            {
                if (_protokoll.InterneNotiz == value)
                    return;
                _protokoll.InterneNotiz = value;
                OnPropertyChanged();
            }
        }

        public string Ursache
        {
            get { return _protokoll.Ursache; }
            set
            {
                if (_protokoll.Ursache == value)
                    return;
                _protokoll.Ursache = value;
                OnPropertyChanged();
            }
        }

        public string UrsachenBeschreibung
        {
            get { return _protokoll.UrsachenBeschreibung; }
            set
            {
                if (_protokoll.UrsachenBeschreibung == value)
                    return;
                _protokoll.UrsachenBeschreibung = value;
                OnPropertyChanged();
            }
        }


        public decimal Approxsumme
        {
            get { return _protokoll.Approxsumme; }
            set
            {
                if (_protokoll.Approxsumme == value)
                    return;
                _protokoll.Approxsumme = value;
                OnPropertyChanged();
            }
        }

        public decimal Selbstbehalt
        {
            get { return _protokoll.Selbstbehalt; }
            set
            {
                if (_protokoll.Selbstbehalt == value)
                    return;
                _protokoll.Selbstbehalt = value;
                OnPropertyChanged();
            }
        }

        public decimal Minimum
        {
            get { return _protokoll.Minimum; }
            set
            {
                if (_protokoll.Minimum == value)
                    return;
                _protokoll.Minimum = value;
                OnPropertyChanged();
            }
        }

        public decimal Maximum
        {
            get { return _protokoll.Maximum; }
            set
            {
                if (_protokoll.Maximum == value)
                    return;
                _protokoll.Maximum = value;
                OnPropertyChanged();
            }
        }

        public DateTime LetzteBearbeitung
        {
            get { return _protokoll.LetzteBearbeitung; }
            set
            {
                if (_protokoll.LetzteBearbeitung == value)
                    return;
                _protokoll.LetzteBearbeitung = value;
                OnPropertyChanged();
            }
        }
    }
}

