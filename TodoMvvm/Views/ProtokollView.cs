using Xamarin.Forms;

namespace ZeusMobile.Views
{
    public class ProtokollView : ContentPage
    {

        public ProtokollView()
        {
            var header = new Label
          {
              Text = "Protokoll",
              FontSize = 16,
              FontAttributes = FontAttributes.Bold,
              HorizontalOptions = LayoutOptions.Center
          };
            header.SetBinding(Label.TextProperty, "ProtokollListeText");

            var beschreibungCell = new EntryCell { Label = "Beschreibung" };
            beschreibungCell.SetBinding(EntryCell.TextProperty, "Beschreibung");

            var ursacheCell = new EntryCell { Label = "Ursache" };
            ursacheCell.SetBinding(EntryCell.TextProperty, "Ursache");

            var ursachenBeschreibungLabel = new Label { Text = "UrsachenBeschreibung" };
            var ursachenBeschreibungEntry = new Entry { };
            ursachenBeschreibungEntry.SetBinding(Entry.TextProperty, "UrsachenBeschreibung");

            var interneNotizLabel = new Label { Text = "InterneNotiz" };
            var interneNotizEntry = new Entry { };
            interneNotizEntry.SetBinding(Entry.TextProperty, "InterneNotiz");

            var approxsummeCell = new EntryCell { Label = "Approxsumme" };
            approxsummeCell.SetBinding(EntryCell.TextProperty, "Approxsumme");

            var selbstbehaltCell = new EntryCell { Label = "Selbstbehalt" };
            selbstbehaltCell.SetBinding(EntryCell.TextProperty, "Selbstbehalt");

            var minimumCell = new EntryCell { Label = "Minimum" };
            minimumCell.SetBinding(EntryCell.TextProperty, "Minimum");

            var maximumCell = new EntryCell { Label = "Maximum" };
            maximumCell.SetBinding(EntryCell.TextProperty, "Maximum");

            var letzteBearbeitungCell = new EntryCell { Label = "LetzteBearbeitung" };
            letzteBearbeitungCell.SetBinding(EntryCell.TextProperty, "LetzteBearbeitung");
            letzteBearbeitungCell.IsEnabled = false;
            
            var tableBeschreibung = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot
                {
                    new TableSection
                    {
                        beschreibungCell,
                        ursacheCell
                    }
                }
            };

            var tableBetraege = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot
                {
                    new TableSection
                    {
                        approxsummeCell,
                        selbstbehaltCell,
                        minimumCell,
                        maximumCell,
                        letzteBearbeitungCell
                    }
                }
            };

            Content = new StackLayout
               {
                   Children = 
                {
                    header,
                    tableBeschreibung,            
                        ursachenBeschreibungLabel,
                        ursachenBeschreibungEntry,
                        interneNotizLabel,
                        interneNotizEntry,
                        tableBetraege
                }
               };
        }

    }
}
