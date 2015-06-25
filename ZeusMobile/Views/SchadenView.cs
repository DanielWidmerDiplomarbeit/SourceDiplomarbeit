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

            var schadenNrCell = new EntryCell { Label = "Schaden Nr." };
            schadenNrCell.SetBinding(EntryCell.TextProperty, "Schaden.Id");

            var statusCell = new EntryCell { Label = "Status" };
            statusCell.SetBinding(EntryCell.TextProperty, "Status");

            var sachbearbeiterCell = new EntryCell { Label = "Sachbearbeiter" };
            sachbearbeiterCell.SetBinding(EntryCell.TextProperty, "Schaden.Sachbearbeiter");

            var mutationsdatumCell = new EntryCell { Label = "Mutationsdatum" };
            mutationsdatumCell.SetBinding(EntryCell.TextProperty, "Schaden.MutationsDatumText");
            mutationsdatumCell.IsEnabled = false;
            
            var prioritaetCell = new EntryCell { Label = "Prioritaet" };
            prioritaetCell.SetBinding(EntryCell.TextProperty, "Prioritaet");

            var meldeDatumLabel = new Label { Text = " Meldedatum" };
            var meldeDatumDatumPicker = new DatePicker { Format = "D" };
            meldeDatumDatumPicker.SetBinding(DatePicker.DateProperty, "Meldedatum");

            var eintrittsDatumDatumLabel = new Label { Text = " Eintrittsdatum" };
            var eintrittsDatumDatumPicker = new DatePicker { Format = "D" };
            eintrittsDatumDatumPicker.SetBinding(DatePicker.DateProperty, "Eintrittsdatum");

            var saveButton = new Button { Text = "Save" };
            saveButton.SetBinding(Button.CommandProperty, "SaveCommand");

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.SetBinding(Button.CommandProperty, "CancelCommand");
            cancelButton.SetBinding(IsVisibleProperty, "CanCancel");

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
                    saveButton, 
                    cancelButton}
            };



        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

                MessagingCenter.Send(this, "InitSchadenView");
        }
    }
}