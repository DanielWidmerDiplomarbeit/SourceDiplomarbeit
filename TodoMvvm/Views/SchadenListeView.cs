using Xamarin.Forms;
using ZeusMobile.Models;

namespace ZeusMobile.Views
{
    public class SchadenListeView : ContentPage
	{
	 bool first = true;

        public SchadenListeView()
        {
            Title = "ZeusMobile";

            NavigationPage.SetHasNavigationBar(this, true);

            var pendenteFaelleLabel = new Label { Text = "Nur Pendente" };
            var pendenteFaelle = new Switch();
            pendenteFaelle.SetBinding(Switch.IsToggledProperty, "NurPendente");
            pendenteFaelle.Toggled += pendenteFaelle_Toggled;


            var listView = new ListView { RowHeight = 40 };
            listView.SetBinding(ListView.ItemsSourceProperty, "SchadensAuswahlListe");
            listView.SetBinding(ListView.SelectedItemProperty, new Binding("SelectedItem", BindingMode.TwoWay));
            listView.ItemTemplate = new DataTemplate(typeof(SchadenItemCell));

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { pendenteFaelleLabel, pendenteFaelle, listView }
            };
        }

        void pendenteFaelle_Toggled(object sender, ToggledEventArgs e)
        {
            MessagingCenter.Send(this, "SchadenListeReload", e.Value);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

			if (!first)
			{
				MessagingCenter.Send(this, "SchadenListeReload");
			};
			first = false;
        }
    }
}
