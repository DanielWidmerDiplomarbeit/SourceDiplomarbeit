using System.Linq;
using Xamarin.Forms;
using ZeusMobile.Models;
using ZeusMobile.Views;

namespace ZeusMobile.ViewModels
{
    class SchadenNavigationViewModel : BaseViewModel
    {
        readonly Schaden _schaden;

        public SchadenNavigationViewModel(Schaden schaden)
        {
            _schaden = schaden;

            InitNavigationView();

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "VersicherteAnzeigen", sender => Navigation.Push(ViewFactory.CreatePage(new VersicherteViewModel(_schaden))));

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "PolicenAnzeigen", sender => Navigation.Push(ViewFactory.CreatePage(new PolicenViewModel(_schaden))));

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "ObjekteAnzeigen", sender => Navigation.Push(ViewFactory.CreatePage(new ObjekteViewModel(_schaden))));

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "SchadenBearbeiten", sender => Navigation.Push(ViewFactory.CreatePage(new SchadenViewModel(_schaden))));

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "ProtokollBearbeiten", sender => Navigation.Push(ViewFactory.CreatePage(new ProtokollViewModel(SchadenProtokoll))));
        }

        public Schaden Schaden { get; set; }
        public SchadenProtokoll SchadenProtokoll { get; set; }
        public Subject Subject { get; set; }
        public Versicherter Versicherter { get; set; }
        public Police Police { get; set; }
        public Versicherungsobjekt Versicherungsobjekt { get; set; }

        private void InitNavigationView()
        {
            Schaden = _schaden;
            ProtokollVomSchadenLesen();
            PoliceVomSchadenLesen();
            ObjektVomSchadenLesen();
        }

        private void ProtokollVomSchadenLesen()
        {
            SchadenProtokoll = App.Database.GetSchadenProtokoll(_schaden.Id) ??
                               new SchadenProtokoll { SchadenId = _schaden.Id, Beschreibung = "Neues Protokoll" };
        }

        private void PoliceVomSchadenLesen()
        {
            Police = App.Database.getPolice(_schaden.Id);
            VersicherterVonPoliceLesen(Police.VersicherterId);
        }

        private void ObjektVomSchadenLesen()
        {
            var alleObjekte = App.Database.getVersicherungsobjekte();
            Versicherungsobjekt = alleObjekte.FirstOrDefault();
        }

        private void VersicherterVonPoliceLesen(int versicherterId)
        {
            var versicherter = App.Database.GetVersicherter(versicherterId);
            if (versicherter != null)
            {
				Subject = App.Database.GetSubject(versicherter.SubjektId);
            }
            else
            {
                Subject = new Subject { Name = "Unbekannt" };
            }

        }

    }
}

