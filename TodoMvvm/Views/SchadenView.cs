using Xamarin.Forms;
using ZeusMobile.Models;

namespace ZeusMobile.Views
{
    public class SchadenView : ContentPage
    {

        public SchadenView()
        {
            this.SetBinding(Page.TitleProperty, "PoliceId");

            NavigationPage.SetHasNavigationBar(this, true);

            var prioritaetLabel = new Label { Text = "Priorität" };
            var prioritaetEntry = new Entry { };
            prioritaetEntry.SetBinding(Entry.TextProperty, "Prioritaet");

            var statusLabel = new Label { Text = "Status" };
            var statusEntry = new Entry { };
            statusEntry.SetBinding(Entry.TextProperty, "Status");


            var hausNrLabel = new Label { Text = "HausNr" };
            var hausNrEntry = new Entry { };
            hausNrEntry.SetBinding(Entry.TextProperty, "HausNr");

            var hausNrZusatzLabel = new Label { Text = "HausNr Zusatz" };
            var hausNrZusatzEntry = new Entry { };
            hausNrZusatzEntry.SetBinding(Entry.TextProperty, "HausNrZusatz");

            var landLabel = new Label { Text = "Land" };
            var landEntry = new Entry { };
            landEntry.SetBinding(Entry.TextProperty, "Land");

            var plzLabel = new Label { Text = "Postleitzahl" };
            var plzEntry = new Entry { };
            plzEntry.SetBinding(Entry.TextProperty, "plz");

            var ortLabel = new Label { Text = "Ort" };
            var ortEntry = new Entry { };
            ortEntry.SetBinding(Entry.TextProperty, "Ort");

            var gemeindeLabel = new Label { Text = "Gemeinde" };
            var gemeindeEntry = new Entry { };
            gemeindeEntry.SetBinding(Entry.TextProperty, "Gemeinde");

            var parzelleLabel = new Label { Text = "Parzelle" };
            var parzelleEntry = new Entry { };
            parzelleEntry.SetBinding(Entry.TextProperty, "Parzelle");

            var gebaeudeNrLabel = new Label { Text = "Gebäudenummer" };
            var gebaeudeNrEntry = new Entry { };
            gebaeudeNrEntry.SetBinding(Entry.TextProperty, "GebaeudeNr");

            var saveButton = new Button { Text = "Save" };
            saveButton.SetBinding(Button.CommandProperty, "SaveCommand");

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.SetBinding(Button.CommandProperty, "CancelCommand");
            cancelButton.SetBinding(IsVisibleProperty, "CanCancel");

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.SetBinding(Button.CommandProperty, "DeleteCommand");
            deleteButton.SetBinding(IsVisibleProperty, "CanDelete");



            var meldeDatumLabel = new Label { Text = "Meldedatum" };
            var meldeDatumDatumPicker = new DatePicker { Format = "D" };
            meldeDatumDatumPicker.SetBinding(DatePicker.DateProperty, "Meldedatum");
   

            var eintrittsDatumDatumLabel = new Label { Text = "Eintrittsdatum" };
            var eintrittsDatumDatumPicker = new DatePicker { Format = "D" };
            eintrittsDatumDatumPicker.SetBinding(DatePicker.DateProperty, "Eintrittsdatum");


            var strasseCell = new EntryCell { Label = "Strasse" };
            strasseCell.SetBinding(EntryCell.TextProperty, "Strasse");


            var tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot
                {
                    new TableSection
                    {
                        strasseCell
                    }
                }
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children = {meldeDatumLabel, meldeDatumDatumPicker, tableView,
                    saveButton, cancelButton, deleteButton}
            };
        }
    }
}