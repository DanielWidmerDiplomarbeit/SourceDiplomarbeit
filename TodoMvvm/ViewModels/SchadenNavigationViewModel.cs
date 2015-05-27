using Xamarin.Forms;
using ZeusMobile.Models;
using ZeusMobile.Views;

namespace ZeusMobile.ViewModels
{
    class SchadenNavigationViewModel : BaseViewModel
    {
        Schaden Schaden;

        public SchadenNavigationViewModel(Schaden schaden)
        {
            Schaden = schaden;

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "VersicherteAnzeigen", sender => Navigation.Push(ViewFactory.CreatePage(new VersicherteViewModel(Schaden))));

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "PolicenAnzeigen", sender => Navigation.Push(ViewFactory.CreatePage(new PolicenViewModel(Schaden))));

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "ObjekteAnzeigen", sender => Navigation.Push(ViewFactory.CreatePage(new ObjekteViewModel(Schaden))));

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "SchadenBearbeiten", sender => Navigation.Push(ViewFactory.CreatePage(new SchadenViewModel(Schaden))));

            MessagingCenter.Subscribe<SchadenNavigationView>(this, "ProtokollBearbeiten", sender => Navigation.Push(ViewFactory.CreatePage(new ProtokollViewModel(Schaden))));
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

    }
}

