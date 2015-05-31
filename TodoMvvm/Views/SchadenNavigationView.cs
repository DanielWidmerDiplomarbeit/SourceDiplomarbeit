using System;
using Xamarin.Forms;
using ZeusMobile.Models;
using ZeusMobile.ViewModels;

namespace ZeusMobile.Views
{
    public class SchadenNavigationView : ContentPage
    {
		private bool first = true;
		
        public SchadenNavigationView()
        {

            var header = new Label
          {
              Text = "Schaden bearbeiten",
              FontSize = 30,
              FontAttributes = FontAttributes.Bold,
              HorizontalOptions = LayoutOptions.Center
          };

            var versicherteNaviCell = new TextCell();
            versicherteNaviCell.SetBinding(TextCell.TextProperty, "Subject.SubjectListeText");
            versicherteNaviCell.Tapped += versicherteNaviCelll_Tapped;

            var policeNaviCell = new TextCell();
            policeNaviCell.SetBinding(TextCell.TextProperty, "Police.PoliceListeText");
            policeNaviCell.Tapped += policeNaviCell_Tapped;

            var objektNaviCell = new TextCell();
            objektNaviCell.SetBinding(TextCell.TextProperty, "Versicherungsobjekt.ObjektListeText");
            objektNaviCell.Tapped += objektNaviCell_Tapped;

            var schadenNaviCell = new TextCell();
            schadenNaviCell.SetBinding(TextCell.TextProperty, "Schaden.SchadenListeText");
            schadenNaviCell.Tapped += schadenNaviCell_Tapped;

            var protokollNaviCell = new TextCell();
            protokollNaviCell.SetBinding(TextCell.TextProperty, "Protokoll.ProtokollListeText");
            protokollNaviCell.Tapped += protokollNaviCell_Tapped;

            var tableView = new TableView
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

            Content = new StackLayout
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

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (!first)
			{
				MessagingCenter.Send(this, "InitNavigationView");
			};
			first = false;
		}
    }
}
