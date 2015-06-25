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

            var ursacheLabel = new Label { Text = " Ursache" };
            var ursacheEntry = new Entry { };
            ursacheEntry.SetBinding(EntryCell.TextProperty, "Ursache");

            var ursachenBeschreibungLabel = new Label { Text = " Ursachen Beschreibung" };
            var ursachenBeschreibungEntry = new Editor { };
            ursachenBeschreibungEntry.SetBinding(Editor.TextProperty, "UrsachenBeschreibung");
            EditorProperties(ursachenBeschreibungEntry, ursachenBeschreibungLabel);

            var beschreibungLabel = new Label { Text = " Beschreibung" };
            var beschreibungEntry = new Editor { };
            beschreibungEntry.SetBinding(Editor.TextProperty, "Beschreibung");
            beschreibungEntry.HeightRequest = 50;
            beschreibungEntry.WidthRequest = 700;
            beschreibungLabel.WidthRequest = 300;
            EditorProperties(beschreibungEntry, beschreibungLabel);


            var interneNotizLabel = new Label { Text = " Interne Notiz" };
            var interneNotizEntry = new Editor { };
            interneNotizEntry.SetBinding(Editor.TextProperty, "InterneNotiz");
            EditorProperties(interneNotizEntry, interneNotizLabel);


            var approxsummeCell = new EntryCell { Label = "Approxsumme" };
            approxsummeCell.SetBinding(EntryCell.TextProperty, "Approxsumme");

            var selbstbehaltCell = new EntryCell { Label = "Selbstbehalt" };
            selbstbehaltCell.SetBinding(EntryCell.TextProperty, "Selbstbehalt");

            var minimumCell = new EntryCell { Label = "Minimum" };
            minimumCell.SetBinding(EntryCell.TextProperty, "Minimum");

            var maximumCell = new EntryCell { Label = "Maximum" };
            maximumCell.SetBinding(EntryCell.TextProperty, "Maximum");

            var letzteBearbeitungCell = new EntryCell { Label = "LetzteBearbeitung" };
            letzteBearbeitungCell.SetBinding(EntryCell.TextProperty, "Protokoll.LetzteBearbeitungText");
            letzteBearbeitungCell.IsEnabled = false;

            var saveButton = new Button { Text = "Save" };
            saveButton.SetBinding(Button.CommandProperty, "SaveCommand");
            saveButton.SetBinding(IsEnabledProperty, "CanSave");
            
            var deleteButton = new Button { Text = "Delete" };
            deleteButton.SetBinding(Button.CommandProperty, "DeleteCommand");
            deleteButton.SetBinding(IsVisibleProperty, "CanDelete");

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.SetBinding(Button.CommandProperty, "CancelCommand");
            cancelButton.SetBinding(IsVisibleProperty, "CanCancel");

            var beschreibungEditorLine = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { beschreibungLabel, beschreibungEntry }
            };

            var ursacheBeschreibungEditorLine = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { ursachenBeschreibungLabel, ursachenBeschreibungEntry }
            };

            var interneEditorLine = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { interneNotizLabel, interneNotizEntry }
            };

            var tableBetraege = new TableView
            {
                Intent = TableIntent.Settings,
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
                    ursacheLabel,
                    ursacheEntry,
                    ursacheBeschreibungEditorLine,
                    beschreibungEditorLine,
                    interneEditorLine,
                    tableBetraege,
                    saveButton,
                    deleteButton,
                    cancelButton
                }
               };
}

        private static void EditorProperties(Editor editor, Label label)
        {
            editor.HeightRequest = 50;
            editor.WidthRequest = 700;
            editor.BackgroundColor = Color.FromRgb(245, 245, 245);
            label.WidthRequest = 300;
        }
    }
}
