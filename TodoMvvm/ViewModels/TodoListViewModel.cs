using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Linq;

namespace TodoMvvm
{
    class TodoListViewModel : BaseViewModel
    {
        ObservableCollection<TodoItemCellViewModel> contents = new ObservableCollection<TodoItemCellViewModel>();

        public ObservableCollection<TodoItemCellViewModel> Contents
        {
            get { return contents; }
            set
            {
                if (contents == value)
                    return;
                contents = value;
                OnPropertyChanged();
            }
        }

        public TodoListViewModel()
        {
            var all = App.Database.GetItems().ToList();

            foreach (var t in all)
            {
                contents.Add(new TodoItemCellViewModel(t));
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

        object selectedItem;
        public object SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem == value)
                    return;
                // something was selected
                selectedItem = value;

                OnPropertyChanged();

                if (selectedItem != null)
                {

                    var todovm = new TodoItemViewModel(((TodoItemCellViewModel)selectedItem).Item);

                    Navigation.Push(ViewFactory.CreatePage(todovm));

                    selectedItem = null;
                }
            }
        }
    }
}

