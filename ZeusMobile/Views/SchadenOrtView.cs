using Xamarin.Forms;

namespace ZeusMobile.Views
{
    public class SchadenOrtView : ContentPage
    {
        public SchadenOrtView()
        {
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

            var sachbearbeiterCell = new EntryCell { Label = "Sachbearbeiter" };
            sachbearbeiterCell.SetBinding(EntryCell.TextProperty, "Schaden.Sachbearbeiter");

            var mutationsdatumCell = new EntryCell { Label = "Mutationsdatum" };
            mutationsdatumCell.SetBinding(EntryCell.TextProperty, "Schaden.Mutationsdatum");
            mutationsdatumCell.IsEnabled = false;

            var saveButton = new Button { Text = "Save" };
            saveButton.SetBinding(Button.CommandProperty, "SaveCommand");

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.SetBinding(Button.CommandProperty, "CancelCommand");
            cancelButton.SetBinding(IsVisibleProperty, "CanCancel");

            var ortTable = new TableView
            {
                Intent = TableIntent.Settings,
                Root = new TableRoot
                {
                    new TableSection("Gebäude")
                    {
                       parzelleCell,
                       gebaeudeNummerCell
                    },
                    new TableSection("Schadenort")
                    {
                        strasseCell, 
                        hausnrCell, 
                        plzCell, 
                        ortCell, 
                        landCell
                    },
                      new TableSection("Status")
                    {
                        sachbearbeiterCell,
                        mutationsdatumCell
                    }
                }
            };

            Content = new StackLayout
            {
                Children = {
                    ortTable,
                    saveButton, 
                    cancelButton}
            };
        }
    }
}