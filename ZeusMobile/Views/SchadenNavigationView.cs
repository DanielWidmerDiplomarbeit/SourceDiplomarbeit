// <copyright company="ZHAW">
// Copyright (c) 2015 All Right Reserved
// </copyright>
// <author>Daniel Widmer</author>
// <date>30.06.2015</date>

using System;
using Xamarin.Forms;

namespace ZeusMobile.Views
{
    public class SchadenNavigationView : ContentPage
    {
        private bool _first = true;

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
            versicherteNaviCell.SetBinding(TextCell.TextProperty, "Person.PersonListeText");
            versicherteNaviCell.Tapped += versicherteNaviCelll_Tapped;

            var policeNaviCell = new TextCell();
            policeNaviCell.SetBinding(TextCell.TextProperty, "Police.PoliceListeText");
            policeNaviCell.Tapped += policeNaviCell_Tapped;

            var objektNaviCell = new TextCell();
            objektNaviCell.SetBinding(TextCell.TextProperty, "Objekt.ObjektListeText");
            objektNaviCell.Tapped += objektNaviCell_Tapped;

            var schadenNaviCell = new TextCell();
            schadenNaviCell.SetBinding(TextCell.TextProperty, "Schaden.SchadenListeText");
            schadenNaviCell.Tapped += schadenNaviCell_Tapped;

            var schadenOrtNaviCell = new TextCell();
            schadenOrtNaviCell.SetBinding(TextCell.TextProperty, "Schaden.SchadenOrtListeText");
            schadenOrtNaviCell.Tapped += schadenOrtNaviCell_Tapped;

            var protokollNaviCell = new TextCell();
            protokollNaviCell.SetBinding(TextCell.TextProperty, "Protokoll.ProtokollListeText");
            protokollNaviCell.Tapped += protokollNaviCell_Tapped;

            var tableView = new TableView
            {
                Intent = TableIntent.Menu,
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
                        schadenNaviCell
                    },
                    new TableSection("Schadenort bearbeiten")
                    {
                         schadenOrtNaviCell
                    },
                    new TableSection("Protokoll bearbeiten")
                    {
                       protokollNaviCell
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

        private void schadenOrtNaviCell_Tapped(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "SchadenOrtBearbeiten");
        }

        private void protokollNaviCell_Tapped(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "ProtokollBearbeiten");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!_first)
            {
                MessagingCenter.Send(this, "InitNavigationView");
            };
            _first = false;
        }
    }
}
