using System;
using Xamarin.Forms;
using ZeusMobile.Models;
using ZeusMobile.ViewModels;

namespace ZeusMobile.Views
{
    public class SchadenNavigationView : ContentPage
    {

        public SchadenNavigationView()
        {


            Label header = new Label
          {
              Text = "Schaden bearbeiten",
              FontSize = 30,
              FontAttributes = FontAttributes.Bold,
              HorizontalOptions = LayoutOptions.Center
          };

            var versicherteNaviCell = new TextCell();
            versicherteNaviCell.SetBinding(TextCell.TextProperty, "Name");
            versicherteNaviCell.Tapped += versicherteNaviCelll_Tapped;

            var policeNaviCell = new TextCell();
            policeNaviCell.SetBinding(TextCell.TextProperty, "PoliceNr");
            policeNaviCell.Tapped += policeNaviCell_Tapped;

            var objektNaviCell = new TextCell();
            objektNaviCell.SetBinding(TextCell.TextProperty, "ObjektNr");
            objektNaviCell.Tapped += objektNaviCell_Tapped;

            var schadenNaviCell = new TextCell();
            schadenNaviCell.SetBinding(TextCell.TextProperty, "Strasse");
            schadenNaviCell.Tapped += schadenNaviCell_Tapped;

            var protokollNaviCell = new TextCell();
            protokollNaviCell.SetBinding(TextCell.TextProperty, "ProtokollId");
            protokollNaviCell.Tapped += protokollNaviCell_Tapped;

            TableView tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("TableView Title")
                {
                       new TableSection("Versicherte anzeigen")
                    {
                        versicherteNaviCell
                    },        
                    new TableSection("Police anzeigen")
                    {
                        policeNaviCell
                    },                  
                    new TableSection("Objekt anzeigen")
                    {
                        objektNaviCell
                    },

                    new TableSection("Schaden bearbeiten")
                    {
                        schadenNaviCell, protokollNaviCell
                    }
                }
            };

            this.Content = new StackLayout
            {
                Children = 
                {
                    header,
                    tableView
                }
            };
        }

        private void versicherteNaviCelll_Tapped(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "VersicherteAnzeigen");
        }
        
        private void policeNaviCell_Tapped(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "PolicenAnzeigen");
        }

        private void objektNaviCell_Tapped(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "ObjekteAnzeigen");
        }

        private void schadenNaviCell_Tapped(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "SchadenBearbeiten");
        }

        private void protokollNaviCell_Tapped(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "ProtokollBearbeiten");
        }



    }
}
