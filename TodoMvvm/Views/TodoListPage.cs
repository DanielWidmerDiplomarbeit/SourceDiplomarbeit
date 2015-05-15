using Xamarin.Forms;

namespace TodoMvvm
{
	public class TodoListPage : ContentPage
	{
		public TodoListPage ()
		{
			Title = "TodoMvvm";

			NavigationPage.SetHasNavigationBar (this, true);

			var listView = new ListView ();
			listView.RowHeight = 40;
			listView.SetBinding (ListView.ItemsSourceProperty, "Contents");
			listView.SetBinding (ListView.SelectedItemProperty, new Binding ("SelectedItem", BindingMode.TwoWay));
			listView.ItemTemplate = new DataTemplate (typeof (TodoItemCell));

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {listView}
			};

			var tbi = new ToolbarItem ("+", null, () => {
				var t = new TodoItem();
				MessagingCenter.Send (this, "TodoAdd", t);
			});
			
			ToolbarItems.Add (tbi);
		}
	}
}

