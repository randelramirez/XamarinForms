using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XamarinForms
{
    public class FramedTextPage : ContentPage
    {
        public FramedTextPage()
        {
            Padding = new Thickness(20);
            BackgroundColor = Color.Aqua;
            // To display centered framed text, you want to set the HorizontalOptions and VerticalOptions properties on the Frame (rather than the Label) 
            // to LayoutOptions.Center
            Content = new Frame
            {
                OutlineColor = Color.Black,
                BackgroundColor = Color.Yellow,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Content = new Label
                {
                    Text = "I've been framed!",
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    FontAttributes = FontAttributes.Italic,
                    TextColor = Color.Blue
                    // setting the vertical and horizontal layout options here will display the Frame filling the entire screen
                    // because => if it’s not in a StackLayout and has its HorizontalOptions and VerticalOptions set to default values of LayoutOptions.Fill
                }
            };
        }
    }
}
