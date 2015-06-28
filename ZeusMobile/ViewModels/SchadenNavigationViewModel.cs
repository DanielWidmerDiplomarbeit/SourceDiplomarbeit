// <copyright company="ZHAW">
// Copyright (c) 2015 All Right Reserved
// </copyright>
// <author>Daniel Widmer</author>
// <date>30.06.2015</date>

using System.Linq;
using Xamarin.Forms;
using ZeusMobile.BaseClassesGD;
using ZeusMobile.Models;
using ZeusMobile.Services;
using ZeusMobile.Views;

namespace ZeusMobile.ViewModels
{
    class SchadenNavigationViewModel : BaseViewModel
    {
        Schaden _schaden;
        private readonly ZeusDbService _zeusDbService;

        public SchadenNavigationViewModel(Schaden schaden)
        {
            _schaden = schaden;
            _zeusDbService = new ZeusDbService(App.Database);

            InitNavigationView();

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "InitNavigationView", sender => InitNavigationView());

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "VersicherteAnzeigen", sender => Navigation.Push(ViewFactory.CreatePage(new VersicherteViewModel(Versicherter, Person))));

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "PolicenAnzeigen", sender => Navigation.Push(ViewFactory.CreatePage(new PolicenViewModel(Police))));

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "ObjekteAnzeigen", sender => Navigation.Push(ViewFactory.CreatePage(new ObjekteViewModel(Objekt))));

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "SchadenBearbeiten", sender => Navigation.Push(ViewFactory.CreatePage(new SchadenViewModel(Schaden))));

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "SchadenOrtBearbeiten", sender => Navigation.Push(ViewFactory.CreatePage(new SchadenOrtViewModel(_schaden))));

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "ProtokollBearbeiten", sender => Navigation.Push(ViewFactory.CreatePage(new ProtokollViewModel(_schaden, Protokoll, App.Database))));
        }

        public Person Person { get; set; }
        public Versicherter Versicherter { get; set; }
        public Police Police { get; set; }
        public Objekt Objekt { get; set; }

        public Schaden Schaden
        {
            get { return _schaden; }
            set
            {
                if (_schaden == value)
                    return;
                _schaden = value;
                OnPropertyChanged();
            }
        }

        private Protokoll _protokoll;
        public Protokoll Protokoll
        {
            get { return _protokoll; }
            set
            {
                if (_protokoll == value)
                    return;
                _protokoll = value;
                OnPropertyChanged();
            }
        }

        private void InitNavigationView()
        {
            SchadenNachlesen();
            ProtokollVomSchadenLesen();
            PoliceVomSchadenLesen();
            ObjektVomSchadenLesen();

        }

        private void SchadenNachlesen()
        {
            Schaden = App.Database.GetSchaden(_schaden.Id);
        }

        private void ProtokollVomSchadenLesen()
        {
            Protokoll = App.Database.GetSchadenProtokoll(_schaden.Id);
            if (Protokoll == null)
            {
                Protokoll = new Protokoll { SchadenId = _schaden.Id, Beschreibung = "Neues Protokoll" };
                _zeusDbService.SaveProtokoll(_schaden, Protokoll);
                Protokoll = _zeusDbService.ReadProtokoll(Schaden.Id);
            }
        }

        private void PoliceVomSchadenLesen()
        {
            Police = App.Database.GetPolice(_schaden.Id);
            VersicherterVonPoliceLesen(Police.VersicherterId);
        }

        private void ObjektVomSchadenLesen()
        {
            var alleObjekte = App.Database.GetVersicherungsobjekte();
            Objekt = alleObjekte.FirstOrDefault();
        }

        private void VersicherterVonPoliceLesen(int versicherterId)
        {
            Versicherter = App.Database.GetVersicherter(versicherterId);
            if (Versicherter != null)
            {
                Person = App.Database.GetSubject(Versicherter.SubjektId);
            }

        }

    }
}

