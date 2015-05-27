using Xamarin.Forms;

namespace ZeusMobile.Views
{
    public class ProtokollView : ContentPage
    {

        public ProtokollView()
        {
            var header = new Label
          {
              Text = "Bearbeiten Protokoll",
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
