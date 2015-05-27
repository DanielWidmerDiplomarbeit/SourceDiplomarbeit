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
              FontSize = 30,
              FontAttributes = FontAttributes.Bold,
              HorizontalOptions = LayoutOptions.Center
          };

            Content = new StackLayout
               {
                   Children = 
                {
                    header
                }
               };
        }

    }
}
