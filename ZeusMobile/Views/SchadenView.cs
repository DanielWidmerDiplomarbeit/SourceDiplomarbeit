using Xamarin.Forms;
using ZeusMobile.Models;

namespace ZeusMobile.Views
{
    public class SchadenView : ContentPage
    {

        public SchadenView()
        {
            var beschreibungCell = new EntryCell { Label = "Beschreibung" };
            beschreibungCell.SetBinding(EntryCell.TextProperty, "Beschreibung");

            var parzelleCell = new EntryCell { Label = "Parzelle" };
            parzelleCell.SetBinding(EntryCell.TextProperty, "Parzelle");

            var gebaeudeNummerCell = new EntryCell { Label = "GebaeudeNummer" };
            gebaeudeNummerCell.SetBinding(EntryCell.TextProperty, "GebaeudeNummer");

            var gemeindeCell = new EntryCell { Label = "Gemeinde" };
            gemeindeCell.SetBinding(EntryCell.TextProperty, "Gemeinde");

            var strasseCell = new EntryCell { Label = "Strasse" };
            strasseCell.SetBinding(EntryCell.TextProperty, "Strasse");

            var hausnrCell = new EntryCell { Label = "Hausnr" };
            hausnrCell.SetBinding(EntryCell.TextProperty, "Hausnr");

            var plzCell = new EntryCell { Label = "Plz" };
            plzCell.SetBinding(EntryCell.TextProperty, "Plz");

            var ortCell = new EntryCell { Label = "Ort" };
            ortCell.SetBinding(EntryCell.TextProperty, "Ort");

            var landCell = new EntryCell { Label = "Land" };
            landCell.SetBinding(EntryCell.TextProperty, "Land");

            var schadenNrCell = new EntryCell { Label = "Schaden Nr." };
            schadenNrCell.SetBinding(EntryCell.TextProperty, "Schaden.Id");

            var statusCell = new EntryCell { Label = "Status" };
            statusCell.SetBinding(EntryCell.TextProperty, "Schaden.Status");

            var sachbearbeiterCell = new EntryCell { Label = "Sachbearbeiter" };
            sachbearbeiterCell.SetBinding(EntryCell.TextProperty, "Schaden.Sachbearbeiter");

            var mutationsdatumCell = new EntryCell { Label = "Mutationsdatum" };
            mutationsdatumCell.SetBinding(EntryCell.TextProperty, "Schaden.Mutationsdatum");
            mutationsdatumCell.IsEnabled = false;

            var prioritaetCell = new EntryCell { Label = "Prioritaet" };
            prioritaetCell.SetBinding(EntryCell.TextProperty, "Schaden.Prioritaet");

            var meldeDatumLabel = new Label { Text = "Meldedatum" };
            var meldeDatumDatumPicker = new DatePicker { Format = "D" };
            meldeDatumDatumPicker.SetBinding(DatePicker.DateProperty, "Meldedatum");
            
            var eintrittsDatumDatumLabel = new Label { Text = "Eintrittsdatum" };
            var eintrittsDatumDatumPicker = new DatePicker { Format = "D" };
            eintrittsDatumDatumPicker.SetBinding(DatePicker.DateProperty, "Eintrittsdatum");
           

            var saveButton = new Button { Text = "Save" };
            saveButton.SetBinding(Button.CommandProperty, "SaveCommand");

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.SetBinding(Button.CommandProperty, "CancelCommand");
            cancelButton.SetBinding(IsVisibleProperty, "CanCancel");

            //var saveButton = new Button { Text = "Save" };
            //saveButton.SetBinding(Button.CommandProperty, "SaveCommand");

            //var cancelButton = new Button { Text = "Cancel" };
            //cancelButton.SetBinding(Button.CommandProperty, "CancelCommand");
            //cancelButton.SetBinding(IsVisibleProperty, "CanCancel");

            //var deleteButton = new Button { Text = "Delete" };
            //deleteButton.SetBinding(Button.CommandProperty, "DeleteCommand");
            //deleteButton.SetBinding(IsVisibleProperty, "CanDelete");

            var schadenKopfTable = new TableView
            {
                Intent = TableIntent.Settings,
                Root = new TableRoot
                {
                    new TableSection
                    {
                       beschreibungCell, 
                       schadenNrCell, 
                       prioritaetCell
                    }
                }
            };

            var ortTable = new TableView
            {
                Intent = TableIntent.Settings,
                Root = new TableRoot
                {
                    new TableSection("Schadenort")
                    {
                        strasseCell, 
                        hausnrCell, 
                        plzCell, 
                        ortCell, 
                        landCell, 
                        parzelleCell, 
                        gebaeudeNummerCell
                    }
                }
            };

            var statusTable = new TableView
            {
                Intent = TableIntent.Settings,
                Root = new TableRoot
                {
                    new TableSection("Status")
                    {
                        statusCell,
                        sachbearbeiterCell,
                        mutationsdatumCell
                    }
                }
            };


            Content = new StackLayout
            {
                //       VerticalOptions = LayoutOptions.StartAndExpand,
                Children = {
                    schadenKopfTable,
                    meldeDatumLabel,
                    meldeDatumDatumPicker,
                    eintrittsDatumDatumLabel,
                    eintrittsDatumDatumPicker,
                    statusTable,
                    ortTable,
                    saveButton, 
                    cancelButton}
            };

        }
    }
}