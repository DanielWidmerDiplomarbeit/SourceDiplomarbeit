using System;
using System.Windows.Input;
using Xamarin.Forms;
using ZeusMobile.Data;
using ZeusMobile.Models;
using ZeusMobile.Services;

namespace ZeusMobile.ViewModels
{
    internal class ProtokollViewModel : BaseViewModel
    {
        private  Schaden _schaden;
        private Protokoll _protokoll;
        private readonly ZeusDbService _zeusDbService;
        ICommand _saveCommand, _deleteCommand, _cancelCommand;

        public ProtokollViewModel(Schaden schaden, Protokoll protokoll, DataBase dataBase)
        {
            _schaden = schaden;
            _protokoll = protokoll;
            _zeusDbService = new ZeusDbService(dataBase);
            _saveCommand = new Command(Save);
            _deleteCommand = new Command(Delete);
            _cancelCommand = new Command(() => Navigation.Pop());
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
        
        public ICommand DeleteCommand
        {
            get { return _deleteCommand; }
            set
            {
                if (_deleteCommand == value)
                    return;
                _deleteCommand = value;
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

        public bool CanDelete
        {
            get { return _protokoll.Id > 0; }
        }
        public bool CanCancel
        {
            get { return !CanDelete; }
        }
        public bool CanSave
        {
            get { return true; }
        }

        public void Delete  ()
        {
            _zeusDbService.DeleteProtokoll( _protokoll);
            MessagingCenter.Send(this, "SchadenSaved", _schaden);
            Navigation.Pop();
        }    
        public void Save()
        {
            _zeusDbService.SaveProtokoll(_schaden, _protokoll);
            MessagingCenter.Send(this, "SchadenSaved", _schaden);
            Navigation.Pop();
        }
        #endregion
    }
}

