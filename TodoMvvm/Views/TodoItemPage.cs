using Xamarin.Forms;

namespace ZeusMobile
{
	public class TodoItemPage : ContentPage
	{
	
		public TodoItemPage ()
		{
			this.SetBinding (ContentPage.TitleProperty, "Name");

			NavigationPage.SetHasNavigationBar (this, true);

			var nameLabel = new Label { Text = "Name" };
			var nameEntry = new Entry { Text = "<new>" };
			nameEntry.SetBinding (Entry.TextProperty, "Name");

			var schDatumLabel = new Label { Text = "Schadensdatum" };
			var schDatumPicker = new DatePicker  {  Format = "D"};
			schDatumPicker.SetBinding (DatePicker.DateProperty, "Schadensdatum");

			var notesLabel = new Label { Text = "Notes" };
			var notesEntry = new Entry ();
			notesEntry.SetBinding (Entry.TextProperty, "Notes");

			var doneLabel = new Label { Text = "Done" };
			var doneEntry = new Switch ();
			doneEntry.SetBinding (Switch.IsToggledProperty, "Done");


			var saveButton = new Button { Text = "Save" };
			saveButton.SetBinding (Button.CommandProperty, "SaveCommand");
			var cancelButton = new Button { Text = "Cancel" };
			cancelButton.SetBinding (Button.CommandProperty, "CancelCommand");
			cancelButton.SetBinding (Button.IsVisibleProperty, "CanCancel");
			var deleteButton = new Button { Text = "Delete" };
			deleteButton.SetBinding (Button.CommandProperty, "DeleteCommand");
			deleteButton.SetBinding (Button.IsVisibleProperty, "CanDelete");


			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness(20),
				Children = {nameLabel, nameEntry, 
					schDatumLabel, schDatumPicker,
					notesLabel, notesEntry,
					doneLabel, doneEntry,
					saveButton, cancelButton, deleteButton}
			};

		}
	}
}

