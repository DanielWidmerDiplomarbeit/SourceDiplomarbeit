// <copyright company="ZHAW">
// Copyright (c) 2015 All Right Reserved
// </copyright>
// <author>Daniel Widmer</author>
// <date>30.06.2015</date>

using Xamarin.Forms;

namespace ZeusMobile.Views
{
    public class SchadenListeView : ContentPage
    {
        bool _first = true;

        public SchadenListeView()
        {
            Title = "ZeusMobile";

            NavigationPage.SetHasNavigationBar(this, true);

            var pendenteFaelleLabel = new Label { Text = "   Nur Pendente" };
            var abstand = new Label { Text = "  " };
            var pendenteFaelle = new Switch();
            pendenteFaelle.SetBinding(Switch.IsToggledProperty, "NurPendente");
            pendenteFaelle.Toggled += pendenteFaelle_Toggled;

            var pendente = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { pendenteFaelleLabel, abstand, pendenteFaelle }
            };

            var sucheLabel = new Label { Text = "Suche:" };
            var suchText = new Entry();
            suchText.SetBinding(Entry.TextProperty, " SucheText");

            var listView = new ListView { RowHeight = 40 };
            listView.SetBinding(ListView.ItemsSourceProperty, "SchadensAuswahlListe");
            listView.SetBinding(ListView.SelectedItemProperty, new Binding("SelectedItem", BindingMode.TwoWay));
            listView.ItemTemplate = new DataTemplate(typeof(SchadenItemCell));

            var searchButton = new Button { Text = "Suche" };
            searchButton.SetBinding(Button.CommandProperty, "SearchCommand");

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { sucheLabel, suchText, searchButton, pendente, listView }
            };
        }

        void pendenteFaelle_Toggled(object sender, ToggledEventArgs e)
        {
            MessagingCenter.Send(this, "SchadenListeReload", e.Value);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!_first)
            {
                MessagingCenter.Send(this, "SchadenListeReload");
            }
            _first = false;
        }
    }
}
