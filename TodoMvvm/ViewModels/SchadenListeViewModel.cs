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


            MessagingCenter.Subscribe<SchadenViewModel, Schaden>(this, "SchadenSave", (sender, model) =>
            {
                App.Database.SaveItem(model);
                Reload();
            });




            //MessagingCenter.Subscribe<SchadenViewModel, Schaden>(this, "SchadenDelete", (sender, model) =>
            //{
            //    App.Database.DeleteItem(model.Id);
            //    Reload();
            //});

            //MessagingCenter.Subscribe<SchadenListeView, Schaden>(this, "SchadenAdd", (sender, viewModel) =>
            //{
            //    var Schaden = new Schaden();
            //    var Schadenvm = new SchadenNavigationViewModel(Schaden);
            //    Navigation.Push(ViewFactory.CreatePage(Schadenvm));
            //});




            MessagingCenter.Subscribe<SchadenNavigationViewModel, Schaden>(this, "SchadenListeReload", (sender, viewModel) =>
                {
                    Reload();
                });
        }

        void Reload()
        {
            var all = App.Database.GetItems().ToList();

            var x = new ObservableCollection<SchadenCellViewModel>();
            foreach (var t in all)
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

                    var Schadenvm = new SchadenNavigationViewModel(((SchadenCellViewModel)_selectedItem).Item);

                    Navigation.Push(ViewFactory.CreatePage(Schadenvm));

                    _selectedItem = null;
                }
            }
        }
    }
}

