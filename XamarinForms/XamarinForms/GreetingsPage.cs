using Xamarin.Forms;

namespace XamarinForms
{
    public class GreetingsPage : ContentPage
    {
        public GreetingsPage()
        {
            var label = new Label
            {
                Text = "Greetings, Xamarin.Forms!",
                //HorizontalOptions = LayoutOptions.Center,
                //VerticalOptions = LayoutOptions.Center
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold | FontAttributes.Italic
            };

            //this.Padding = Device.OnPlatform<Thickness>(new Thickness(0, 0, 0, 0), new Thickness(0, 0, 0, 0), new Thickness(0, 20, 0, 0));
            //this.Padding = new Thickness(0, Device.OnPlatform(0, 0, 20), 0, 0); //padding applied to windows
            Device.OnPlatform(null, null, () => { this.Padding = new Thickness(0, 20, 0, 0); }); //padding applied to windows
            //Device.OnPlatform(iOS: () => { this.Padding = new Thickness(0, 20, 0, 0); }); //padding for iOS
            this.Content = label;
        }
    }
}
