// <copyright company="ZHAW">
// Copyright (c) 2015 All Right Reserved
// </copyright>
// <author>Daniel Widmer</author>
// <date>30.06.2015</date>
using System;
using System.Windows.Input;
using Xamarin.Forms;
using ZeusMobile.BaseClassesGD;
using ZeusMobile.Models;

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
        public string Prioritaet
        {
            get
            {
                return ConvertToString(Schaden.Prioritaet);

            }
        }
        public string Status
        {
            get
            {
                return ConvertToString(Schaden.Status);
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

        #region Methoden
        public bool CanSave
        {
            get { return Schaden.Id > 0; }
        }
        public void Save()
        {
            MessagingCenter.Send(this, "SchadenSaved", Schaden);
            Navigation.Pop();
        }
        public static String ConvertToString(Enum eEnum)
        {
            return Enum.GetName(eEnum.GetType(), eEnum);
        }
        #endregion
    }
}

