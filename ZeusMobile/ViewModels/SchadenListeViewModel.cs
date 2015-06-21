using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using ZeusMobile.Models;
using ZeusMobile.Services;


namespace ZeusMobile.ViewModels
{
    class SchadenListeViewModel : BaseViewModel
    {
        private ObservableCollection<SchadenCellViewModel> _schadensAuswahlListe = new ObservableCollection<SchadenCellViewModel>();


        private readonly ZeusDbService _zeusDbService;
        private List<Schaden> _alleSchaeden;
        private ICommand _searchCommand;
        
        public SchadenListeViewModel()
        {
            _zeusDbService = new ZeusDbService(App.Database);
            _searchCommand = new Command(Load);
            NurPendente = true;

            Load();
            
            MessagingCenter.Subscribe<SchadenListeViewModel, Schaden>(this, "SchadenListeReload", (sender, viewModel) => Load());
            MessagingCenter.Subscribe<SchadenOrtViewModel, Schaden>(this, "SchadenOrtSaved", (sender, schaden) =>
            {
                _zeusDbService.SaveSchaden(schaden);
                Load();
            });
            
            MessagingCenter.Subscribe<SchadenViewModel, Schaden>(this, "SchadenSaved", (sender, schaden) =>
            {
                _zeusDbService.SaveSchaden(schaden);
                Load();
            });
            
            MessagingCenter.Subscribe<ProtokollViewModel, Schaden>(this, "SchadenSaved", (sender, schaden) =>
            {
                _zeusDbService.SaveSchaden(schaden);
                Load();
            });

        }

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
                Load();
            }
        }

        private string _sucheText;
        public string SucheText
        {
            get { return _sucheText; }
            set
            {
                if (_sucheText == value)
                    return;

                _sucheText = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand
        {
            get { return _searchCommand; }
            set
            {
                if (_searchCommand == value)
                    return;
                _searchCommand = value;
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

        void Load()
        {
            _alleSchaeden = _zeusDbService.ReadSchadenListe().ToList();

            Filter();
        }
        private void Filter()
        {
            SchadensAuswahlListe = new ObservableCollection<SchadenCellViewModel>();

            foreach (var schaden in _alleSchaeden)
            {
                if (!NurPendente || NurPendente && schaden.Status < Schaden.EnumStatus.Aufgenommen)
                {
                    if (string.IsNullOrEmpty(SucheText) || schaden.Ort.ToUpper().Contains(SucheText.ToUpper()) || schaden.Beschreibung.ToUpper().Contains(SucheText.ToUpper()))
                    {
                        SchadensAuswahlListe.Add(new SchadenCellViewModel(schaden));
                    }
                }
            }
        }
    }
}

