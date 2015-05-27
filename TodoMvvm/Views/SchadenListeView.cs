using Xamarin.Forms;
using ZeusMobile.Models;

namespace ZeusMobile.Views
{
	public class SchadenListeView : ContentPage
	{	

		
		public SchadenListeView ()
		{
			Title = "ZeusMobile";

			NavigationPage.SetHasNavigationBar (this, true);

			var pendenteFaelleLabel = new Label { Text = "Nur Pendente" };
			var pendenteFaelle = new Switch ();
			pendenteFaelle.SetBinding (Switch.IsToggledProperty, "NurPendente");
			pendenteFaelle.Toggled += pendenteFaelle_Toggled;
		    

			var listView = new ListView { RowHeight = 40 };
			listView.SetBinding (ListView.ItemsSourceProperty, "SchadensAuswahlListe");
			listView.SetBinding (ListView.SelectedItemProperty, new Binding ("SelectedItem", BindingMode.TwoWay));
			listView.ItemTemplate = new DataTemplate (typeof(SchadenItemCell));

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = { pendenteFaelleLabel, pendenteFaelle, listView }
			};

		
			var tbi = new ToolbarItem ("+", null, () => {
				var t = new Schaden ();
				MessagingCenter.Send (this, "SchadenAdd", t);
			});

			ToolbarItems.Add (tbi);
		}

		void pendenteFaelle_Toggled(object sender, ToggledEventArgs e)
		{
			MessagingCenter.Send (this, "SchadenListeReload", e.Value);
		}
	}
}
