using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XamarinForms
{
    public class VariableFormattedTextPage : ContentPage
    {
        public VariableFormattedTextPage()
        {
            Content = new Label
            {
                FormattedText = new FormattedString
                {
                    Spans = {
                        new Span { Text = "I "},
                        new Span { Text = "love", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), FontAttributes = FontAttributes.Bold },
                        new Span { Text = " Xamarin.Forms!" }
                    }
                },
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
        }
    }
}
