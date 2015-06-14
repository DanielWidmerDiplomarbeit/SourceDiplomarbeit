using System;
using System.Globalization;
using System.Windows.Input;
using Xamarin.Forms;
using ZeusMobile.Models;
using ZeusMobile.Views;

namespace ZeusMobile.ViewModels
{
    class SchadenViewModel : BaseViewModel
    {
       
        ICommand _saveCommand, _cancelCommand;

        public SchadenViewModel(Schaden schaden)
        {
            Schaden = schaden;
            _saveCommand = new Command(Save);
            _cancelCommand = new Command(() => Navigation.Pop());
        }

        #region nur lesbare Properties
        
        public Schaden Schaden { get; set; }

        #endregion

        #region schreibbare Properties

        public string Gemeinde
        {
            get
            {
                return Schaden.Gemeinde;
            }
            set
            {
                if (Schaden.Gemeinde == value)
                    return;
                Schaden.Gemeinde = value;
                OnPropertyChanged();
            }
        }
        public string Strasse
        {
            get
            {
                return Schaden.Strasse;
            }
            set
            {
                if (Schaden.Strasse == value)
                    return;
                Schaden.Strasse = value;
                OnPropertyChanged();
            }
        }
        public String Hausnr
        {
            get
            {
                return Schaden.Hausnr;
            }
            set
            {
                if (Schaden.Hausnr == value)
                    return;
                Schaden.Hausnr = value;
                OnPropertyChanged();
            }
        }
        public String Plz
        {
            get
            {
                return Schaden.Plz;
            }
            set
            {
                if (Schaden.Plz == value)
                    return;
                Schaden.Plz = value;
                OnPropertyChanged();
            }
        }
        public String Ort
        {
            get
            {
                return Schaden.Ort;
            }
            set
            {
                if (Schaden.Ort == value)
                    return;
                Schaden.Ort = value;
                OnPropertyChanged();
            }
        }
        public String Land
        {
            get
            {
                return Schaden.Land;
            }
            set
            {
                if (Schaden.Land == value)
                    return;
                Schaden.Land = value;
                OnPropertyChanged();
            }
        }
        public string Beschreibung
        {
            get
            {
                return Schaden.Beschreibung;
            }
            set
            {
                if (Schaden.Beschreibung == value)
                    return;
                Schaden.Beschreibung = value;
                OnPropertyChanged();
            }
        }
        public int Parzelle
        {
            get
            {
                return Schaden.Parzelle;
            }
            set
            {
                if (Schaden.Parzelle == value)
                    return;
                Schaden.Parzelle = value;
                OnPropertyChanged();
            }
        }
        public int Gebaedenummer
        {
            get
            {
                return Schaden.GebaeudeNummer;
            }
            set
            {
                if (Schaden.GebaeudeNummer == value)
                    return;
                Schaden.GebaeudeNummer = value;
                OnPropertyChanged();
            }
        }
        public Schaden.EnumPrioritaet Prioritaet
        {
            get
            {
                return Schaden.Prioritaet;
            }
            set
            {
                if (Schaden.Prioritaet == value)
                    return;
                Schaden.Prioritaet = value;
                OnPropertyChanged();
            }
        }
        public Schaden.EnumStatus Status
        {
            get
            {
                return Schaden.Status;
            }
            set
            {
                if (Schaden.Status == value)
                    return;
                Schaden.Status = value;
                OnPropertyChanged();
            }
        }

        #endregion


        #region commands
        public ICommand SaveCommand
        {
            get { return _saveCommand; }
            set
            {
                if (_saveCommand == value)
                    return;
                _saveCommand = value;
                OnPropertyChanged();
            }
        }
        public ICommand CancelCommand
        {
            get { return _cancelCommand; }
            set
            {
                if (_cancelCommand == value)
                    return;
                _cancelCommand = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region commandMethoden
        public bool CanSave
        {
            get { return Schaden.Id > 0; }
        }
        public void Save()
        {
            MessagingCenter.Send(this, "SchadenSaved", Schaden);
            MessagingCenter.Send(this, "SchadenReload", Schaden);
            Navigation.Pop();
        }
        #endregion
    }
}

