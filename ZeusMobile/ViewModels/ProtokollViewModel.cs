// <copyright company="ZHAW">
// Copyright (c) 2015 All Right Reserved
// </copyright>
// <author>Daniel Widmer</author>
// <date>30.06.2015</date>
using System;
using System.Windows.Input;
using Xamarin.Forms;
using ZeusMobile.BaseClassesGD;
using ZeusMobile.Data;
using ZeusMobile.Models;
using ZeusMobile.Services;

namespace ZeusMobile.ViewModels
{
    internal class ProtokollViewModel : BaseViewModel
    {
        private  Schaden _schaden;
        private readonly ZeusDbService _zeusDbService;
        ICommand _saveCommand, _deleteCommand, _cancelCommand;

        public ProtokollViewModel(Schaden schaden, Protokoll protokoll, DataBase dataBase)
        {
            _schaden = schaden;
            Protokoll = protokoll;
            _zeusDbService = new ZeusDbService(dataBase);
            _saveCommand = new Command(Save);
            _deleteCommand = new Command(Delete);
            _cancelCommand = new Command(() => Navigation.Pop());
        }

        public Protokoll Protokoll { get; set; }

        public int Id
        {
            get { return Protokoll.Id; }
        }

        public string ProtokollListeText
        {
            get { return Protokoll.ProtokollListeText; }
        }

        public string Beschreibung
        {
            get { return Protokoll.Beschreibung; }
            set
            {
                if (Protokoll.Beschreibung == value)
                    return;
                Protokoll.Beschreibung = value;
                OnPropertyChanged();
            }
        }

        public string InterneNotiz
        {
            get { return Protokoll.InterneNotiz; }
            set
            {
                if (Protokoll.InterneNotiz == value)
                    return;
                Protokoll.InterneNotiz = value;
                OnPropertyChanged();
            }
        }

        public string Ursache
        {
            get { return Protokoll.Ursache; }
            set
            {
                if (Protokoll.Ursache == value)
                    return;
                Protokoll.Ursache = value;
                OnPropertyChanged();
            }
        }

        public string UrsachenBeschreibung
        {
            get { return Protokoll.UrsachenBeschreibung; }
            set
            {
                if (Protokoll.UrsachenBeschreibung == value)
                    return;
                Protokoll.UrsachenBeschreibung = value;
                OnPropertyChanged();
            }
        }

        public decimal Approxsumme
        {
            get { return Protokoll.Approxsumme; }
            set
            {
                if (Protokoll.Approxsumme == value)
                    return;
                Protokoll.Approxsumme = value;
                OnPropertyChanged();
            }
        }

        public decimal Selbstbehalt
        {
            get { return Protokoll.Selbstbehalt; }
            set
            {
                if (Protokoll.Selbstbehalt == value)
                    return;
                Protokoll.Selbstbehalt = value;
                OnPropertyChanged();
            }
        }

        public decimal Minimum
        {
            get { return Protokoll.Minimum; }
            set
            {
                if (Protokoll.Minimum == value)
                    return;
                Protokoll.Minimum = value;
                OnPropertyChanged();
            }
        }

        public decimal Maximum
        {
            get { return Protokoll.Maximum; }
            set
            {
                if (Protokoll.Maximum == value)
                    return;
                Protokoll.Maximum = value;
                OnPropertyChanged();
            }
        }

        public DateTime LetzteBearbeitung
        {
            get { return Protokoll.LetzteBearbeitung; }
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
            get { return Protokoll.Id > 0; }
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
            _zeusDbService.DeleteProtokoll( Protokoll);
            MessagingCenter.Send(this, "SchadenSaved", _schaden);
            Navigation.Pop();
        }    
        public void Save()
        {
            _zeusDbService.SaveProtokoll(_schaden, Protokoll, Schaden.EnumStatus.Aufgenommen);
            MessagingCenter.Send(this, "SchadenSaved", _schaden);
            Navigation.Pop();
        }
        #endregion
    }
}

