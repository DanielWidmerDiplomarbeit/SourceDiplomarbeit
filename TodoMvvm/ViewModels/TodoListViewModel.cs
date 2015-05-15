using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using ZeusMobile.Models;
using ZeusMobile.Views;

namespace ZeusMobile.ViewModels
{
    class TodoListViewModel : BaseViewModel
    {
        ObservableCollection<TodoItemCellViewModel> _contents = new ObservableCollection<TodoItemCellViewModel>();

        public ObservableCollection<TodoItemCellViewModel> Contents
        {
            get { return _contents; }
            set
            {
                if (_contents == value)
                    return;
                _contents = value;
                OnPropertyChanged();
            }
        }

        public TodoListViewModel()
        {
            var all = App.Database.GetItems().ToList();

            foreach (var t in all)
            {
                _contents.Add(new TodoItemCellViewModel(t));
            }

            MessagingCenter.Subscribe<TodoItemViewModel, TodoItem>(this, "TodoSaved", (sender, model) =>
            {
                App.Database.SaveItem(model);
                Reload();
            });

            MessagingCenter.Subscribe<TodoItemViewModel, TodoItem>(this, "TodoDeleted", (sender, model) =>
            {
                App.Database.DeleteItem(model.ID);
                Reload();
            });

            MessagingCenter.Subscribe<TodoListPage, TodoItem>(this, "TodoAdd", (sender, viewModel) =>
            {
                var todo = new TodoItem();
                var todovm = new TodoItemViewModel(todo);
                Navigation.Push(ViewFactory.CreatePage(todovm));
            });
        }

        void Reload()
        {
            var all = App.Database.GetItems().ToList();

            // HACK: this kinda breaks iOS "NSInternalInconsistencyException". Works fine in Android.
            //			Contents.Clear ();
            //			foreach (var t in all) {
            //				Contents.Add (new TodoItemCellViewModel (t));
            //			}

            // HACK: this works in iOS.
            var x = new ObservableCollection<TodoItemCellViewModel>();
            foreach (var t in all)
            {
                x.Add(new TodoItemCellViewModel(t));
            }
            Contents = x;
        }

        object _selectedItem;
        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem == value)
                    return;
                // something was selected
                _selectedItem = value;

                OnPropertyChanged();

                if (_selectedItem != null)
                {

                    var todovm = new TodoItemViewModel(((TodoItemCellViewModel)_selectedItem).Item);

                    Navigation.Push(ViewFactory.CreatePage(todovm));

                    _selectedItem = null;
                }
            }
        }
    }
}

