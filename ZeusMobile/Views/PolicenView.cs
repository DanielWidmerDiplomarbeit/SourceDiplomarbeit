// <copyright company="ZHAW">
// Copyright (c) 2015 All Right Reserved
// </copyright>
// <author>Daniel Widmer</author>
// <date>30.06.2015</date>

using Xamarin.Forms;

namespace ZeusMobile.Views
{
    public class PolicenView : ContentPage
    {

        public PolicenView()
        {
            var header = new Label
          {
              Text = "Anzeige Policen",
              FontSize = 18,
              FontAttributes = FontAttributes.Bold,
              HorizontalOptions = LayoutOptions.Center
          };

            var policenNrCell = new EntryCell { Label = "Policen-Nummer" };
            policenNrCell.SetBinding(EntryCell.TextProperty, "Police.PolicenNr");

            var bezeichnungCell = new EntryCell { Label = "Bezeichnung" };
            bezeichnungCell.SetBinding(EntryCell.TextProperty, "Police.Bezeichnung");

            var abteilungCell = new EntryCell { Label = "Abteilung" };
            abteilungCell.SetBinding(EntryCell.TextProperty, "Police.Abteilung");

            var kategorieCell = new EntryCell { Label = "Kategorie" };
            kategorieCell.SetBinding(EntryCell.TextProperty, "Police.Kategorie");

            var brancheCell = new EntryCell { Label = "Branche" };
            brancheCell.SetBinding(EntryCell.TextProperty, "Police.Branche");


            var deckungCell = new EntryCell { Label = "Deckung" };
            deckungCell.SetBinding(EntryCell.TextProperty, "Police.Deckung");
            

            var policeTable = new TableView
            {
                Intent = TableIntent.Settings,
                Root = new TableRoot
                {
                    new TableSection("Generell")
                    {
                        policenNrCell,
                        bezeichnungCell
                    },
                    new TableSection("Inhalt")
                    {
                        abteilungCell, 
                        brancheCell, 
                        kategorieCell, 
                        deckungCell
                    }
                }
            };


            Content = new StackLayout
               {
                   Children = 
                {
                    header,
                    policeTable
                }
               };
        }

    }
}
