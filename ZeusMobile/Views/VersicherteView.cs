// <copyright company="ZHAW">
// Copyright (c) 2015 All Right Reserved
// </copyright>
// <author>Daniel Widmer</author>
// <date>30.06.2015</date>

using Xamarin.Forms;

namespace ZeusMobile.Views
{
    public class VersicherteView : ContentPage
    {

        public VersicherteView()
        {
            var header = new Label
          {
              Text = "Anzeige Versicherter",
              FontSize = 18,
              FontAttributes = FontAttributes.Bold,
              HorizontalOptions = LayoutOptions.Center
          };

            var nameCell = new EntryCell { Label = "Name" };
            nameCell.SetBinding(EntryCell.TextProperty, "Person.Name");

            var vornameCell = new EntryCell { Label = "Vorname" };
            vornameCell.SetBinding(EntryCell.TextProperty, "Person.Vorname");

            var strasseCell = new EntryCell { Label = "Strasse" };
            strasseCell.SetBinding(EntryCell.TextProperty, "Person.Strasse");

            var nummerCell = new EntryCell { Label = "Nummer" };
            nummerCell.SetBinding(EntryCell.TextProperty, "Person.Nummer");

            var plzCell = new EntryCell { Label = "PLZ" };
            plzCell.SetBinding(EntryCell.TextProperty, "Person.Plz");

            var ortCell = new EntryCell { Label = "Ort" };
            ortCell.SetBinding(EntryCell.TextProperty, "Person.Ort");

            var geburtsdatumCell = new EntryCell { Label = "Geburtsdatum" };
            geburtsdatumCell.SetBinding(EntryCell.TextProperty, "Person.Geburtsdatum");

            var kundenNrCell = new EntryCell { Label = "Versichertern-Nummer" };
            kundenNrCell.SetBinding(EntryCell.TextProperty, "Versicherter.VersichertenNr");

            var kundeSeitCell = new EntryCell { Label = "Kunde seit" };
            kundeSeitCell.SetBinding(EntryCell.TextProperty, "KundeSeitAnzeige");

            var personTable = new TableView
             {
                 Intent = TableIntent.Settings,
                 Root = new TableRoot
                {
                    new TableSection ("Personendaten")
                    {
                        vornameCell,
                        nameCell,
                        strasseCell,
                        plzCell,
                        ortCell
                    },
                    new TableSection("Kundendaten")
                    {
                        kundenNrCell,
                        kundeSeitCell
                    } 
                }
             };


            Content = new StackLayout
               {
                   Children =
                   {
                       header,
                       personTable,
                   }
               };
        }

    }
}
