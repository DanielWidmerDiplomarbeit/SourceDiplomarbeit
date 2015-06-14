using Xamarin.Forms;

namespace ZeusMobile.Views
{
    public class ObjekteView : ContentPage
    {

        public ObjekteView()
        {
            var header = new Label
          {
              Text = "Anzeige Objekte",
              FontSize = 18,
              FontAttributes = FontAttributes.Bold,
              HorizontalOptions = LayoutOptions.Center
          };


            var bezeichnungCell = new EntryCell { Label = "Bezeichnung" };
            bezeichnungCell.SetBinding(EntryCell.TextProperty, "Objekt.Bezeichnung");

            var bauartCell = new EntryCell { Label = "Bauart" };
            bauartCell.SetBinding(EntryCell.TextProperty, "Objekt.Bauart");

            var hydrantCell = new EntryCell { Label = "Hydrant" };
            hydrantCell.SetBinding(EntryCell.TextProperty, "Objekt.Hydrant");


            var objektTable = new TableView
            {
                Intent = TableIntent.Settings,
                Root = new TableRoot
                {
                    new TableSection("Generell")
                    {
                        bezeichnungCell,
                        bauartCell
                    },
                    new TableSection("Infrastruktur")
                    {
                    hydrantCell
                    }
                }
            };

            Content = new StackLayout
               {
                   Children = 
                {
                    header,
                    objektTable
                }
               };
        }

    }
}
