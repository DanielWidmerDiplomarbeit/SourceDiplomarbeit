using System.Linq;
using Xamarin.Forms;
using ZeusMobile.Models;
using ZeusMobile.Views;

namespace ZeusMobile.ViewModels
{
    class SchadenNavigationViewModel : BaseViewModel
    {
        Schaden _schaden;

        public SchadenNavigationViewModel(Schaden schaden)
        {
            _schaden = schaden;

            InitNavigationView();

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "InitNavigationView", sender => InitNavigationView());

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "VersicherteAnzeigen", sender => Navigation.Push(ViewFactory.CreatePage(new VersicherteViewModel(Versicherter, Person))));

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "PolicenAnzeigen", sender => Navigation.Push(ViewFactory.CreatePage(new PolicenViewModel(Police))));

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "ObjekteAnzeigen", sender => Navigation.Push(ViewFactory.CreatePage(new ObjekteViewModel(Objekt))));

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "SchadenBearbeiten", sender => Navigation.Push(ViewFactory.CreatePage(new SchadenViewModel(_schaden))));

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "ProtokollBearbeiten", sender => Navigation.Push(ViewFactory.CreatePage(new ProtokollViewModel(Protokoll))));
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
            Protokoll = App.Database.GetSchadenProtokoll(_schaden.Id) ??
                               new Protokoll { SchadenId = _schaden.Id, Beschreibung = "Neues Protokoll" };
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

