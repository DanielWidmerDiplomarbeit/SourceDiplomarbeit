using System;
using System.Windows.Input;
using Xamarin.Forms;
using ZeusMobile.Models;
using ZeusMobile.Views;

namespace ZeusMobile.ViewModels
{
	class SchadenViewModel : BaseViewModel
	{
		Schaden Schaden;

		ICommand _saveCommand, _cancelCommand;

        public SchadenViewModel(Schaden schadenItem)
		{
			Schaden = schadenItem;
			_saveCommand = new Command (Save);
			_cancelCommand = new Command (() => Navigation.Pop ());
		}

		public void Save ()
		{
			MessagingCenter.Send (this, "SchadenSaved", Schaden);
			MessagingCenter.Send (this, "SchadenReload", Schaden);
			Navigation.Pop ();
		}
        
		public int Id {
			get { return Schaden.Id; }
			set {
				if (Schaden.Id == value)
					return;
				Schaden.Id = value;
				OnPropertyChanged ();
			}
		}


		public string Strasse {
		    get
		    {
		        return Schaden.Strasse;
		    }
			set {
				if (Schaden.Strasse == value)
					return;
				Schaden.Strasse = value;
				OnPropertyChanged ();
			}
		}

        public int Hausnr
        {
            get
            {
                return Schaden.Hausnr;
            }
            set
            {
                if (Schaden.Hausnr == value)
                    return;
                Schaden.Hausnr = value;
                OnPropertyChanged();
            }
        }
        public string HausnrZusatz
        {
            get
            {
                return Schaden.HausNrZusatz;
            }
            set
            {
                if (Schaden.HausNrZusatz == value)
                    return;
                Schaden.HausNrZusatz = value;
                OnPropertyChanged();
            }
        }

        public bool CanSave {
			get { return Schaden.Id > 0; }
		}

        //public ICommand SaveCommand {
        //    get { return _saveCommand; }
        //    set {
        //        if (_saveCommand == value)
        //            return;
        //        _saveCommand = value;
        //        OnPropertyChanged ();
        //    }
        //}
	
        //public ICommand CancelCommand {
        //    get { return _cancelCommand; }
        //    set {
        //        if (_cancelCommand == value)
        //            return;
        //        _cancelCommand = value;
        //        OnPropertyChanged ();
        //    }
        //}
			
	}
}

