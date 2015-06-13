using Xamarin.Forms;

namespace ZeusMobile.Views
{
    public class PolicenView : ContentPage
    {

        public PolicenView()
        {
            var header = new Label
          {
              Text = "Anzeige Policen",
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
