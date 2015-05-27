using Xamarin.Forms;

namespace ZeusMobile.Views
{
    public class VersicherteView : ContentPage
    {

        public VersicherteView()
        {
            var header = new Label
          {
              Text = "Anzeige Versicherte",
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
