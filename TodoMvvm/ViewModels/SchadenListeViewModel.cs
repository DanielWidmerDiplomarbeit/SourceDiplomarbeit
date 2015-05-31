using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using ZeusMobile.Models;
using ZeusMobile.Views;

namespace ZeusMobile.ViewModels
{
    class SchadenListeViewModel : BaseViewModel
    {
        ObservableCollection<SchadenCellViewModel> _schadensAuswahlListe = new ObservableCollection<SchadenCellViewModel>();

        public ObservableCollection<SchadenCellViewModel> SchadensAuswahlListe
        {
            get { return _schadensAuswahlListe; }
            set
            {
                if (_schadensAuswahlListe == value)
                    return;
                _schadensAuswahlListe = value;
                OnPropertyChanged();
            }
        }

        public SchadenListeViewModel()
        {
            var all = App.Database.GetSchaeden().ToList();

            foreach (var t in all)
            {
                _schadensAuswahlListe.Add(new SchadenCellViewModel(t));
            }
            
			MessagingCenter.Subscribe<SchadenListeViewModel, Schaden>(this, "SchadenListeReload", (sender, viewModel) => Reload());
			MessagingCenter.Subscribe<SchadenViewModel, Schaden>(this, "SchadenSaved", (sender, model) =>
            {
                App.Database.SaveSchaden(model);
                Reload();
            });

        }

        void Reload()
        {
            var alleSchaeden = App.Database.GetSchaeden().ToList();

            var x = new ObservableCollection<SchadenCellViewModel>();
            foreach (var t in alleSchaeden)
            {
                x.Add(new SchadenCellViewModel(t));
            }
            SchadensAuswahlListe = x;
        }

        private bool _nurPendente;
        public bool NurPendente
        {
            get { return _nurPendente; }
            set
            {
                if (_nurPendente == value)
                    return;

                _nurPendente = value;
                OnPropertyChanged();
            }
        }

        object _selectedItem;
        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem == value)
                    return;

                _selectedItem = value;

                OnPropertyChanged();

                if (_selectedItem != null)
                {

                    var schadenvm = new SchadenNavigationViewModel(((SchadenCellViewModel)_selectedItem).Schaden);

                    Navigation.Push(ViewFactory.CreatePage(schadenvm));

                    _selectedItem = null;
                }
            }
        }
    }
}

