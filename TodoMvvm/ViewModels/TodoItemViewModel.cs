using System;
using System.Windows.Input;
using Xamarin.Forms;
using ZeusMobile.Models;

namespace ZeusMobile.ViewModels
{
	class TodoItemViewModel : BaseViewModel
	{
		TodoItem todo;

		ICommand _saveCommand, _deleteCommand, _cancelCommand;

		public TodoItemViewModel (TodoItem todoItem)
		{
			todo = todoItem;
			_saveCommand = new Command (Save);
			_deleteCommand = new Command (Delete);
			_cancelCommand = new Command (() => Navigation.Pop ());
		}

		public void Save ()
		{
			MessagingCenter.Send (this, "TodoSaved", todo);
			Navigation.Pop ();
		}

		public void Delete ()
		{
			MessagingCenter.Send (this, "TodoDeleted", todo);
			Navigation.Pop ();
		}

	

		public string Name {
			get { return todo.Name; }
			set {
				if (todo.Name == value)
					return;
				todo.Name = value;
				OnPropertyChanged ();
			}
		}

		public DateTime Schadensdatum {
			get { 

				if (todo.Schadensdatum.Equals( DateTime.MinValue)) { 
					todo.Schadensdatum = DateTime.Now;
				}
				return todo.Schadensdatum; 
			}
			set {
				if (todo.Schadensdatum == value)
					return;
				todo.Schadensdatum = value;
				OnPropertyChanged ();
			}
		}

		public string Notes {
			get { return todo.Notes; }
			set {
				if (todo.Notes == value)
					return;
				todo.Notes = value;
				OnPropertyChanged ();
			}
		}

		public bool Done {
			get { return todo.Done; }
			set {
				if (todo.Done == value)
					return;
				todo.Done = value;
				OnPropertyChanged ();
			}
		}

		public bool CanDelete {
			get { return todo.ID > 0; }
		}

		public bool CanCancel {
			get { return !CanDelete; }
		}
			

		public ICommand SaveCommand {
			get { return _saveCommand; }
			set {
				if (_saveCommand == value)
					return;
				_saveCommand = value;
				OnPropertyChanged ();
			}
		}

		public ICommand DeleteCommand {
			get { return _deleteCommand; }
			set {
				if (_deleteCommand == value)
					return;
				_deleteCommand = value;
				OnPropertyChanged ();
			}
		}

		public ICommand CancelCommand {
			get { return _cancelCommand; }
			set {
				if (_cancelCommand == value)
					return;
				_cancelCommand = value;
				OnPropertyChanged ();
			}
		}
			
	}
}

