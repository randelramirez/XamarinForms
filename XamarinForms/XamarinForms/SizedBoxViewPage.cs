using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XamarinForms
{
    public class SizedBoxViewPage : ContentPage
    {
        public SizedBoxViewPage()
        {
            //Content = new BoxView
            //{
            //    Color = Color.Accent,
            //    HorizontalOptions = LayoutOptions.Center,
            //    VerticalOptions = LayoutOptions.Center
            //    // The BoxView is now 40 units square because the BoxView initializes its WidthRequest and HeightRequest properties to 40.
            //};

            BackgroundColor = Color.Pink;
            
            // If you want a view to be a specific size, you can set the WidthRequest and HeightRequest properties.
            // But these properties indicate(as their names suggest) a requested size or a preferred size.
            // If the view is allowed to fill its container, these properties will be ignored.
            Content = new BoxView
            {
                Color = Color.Navy,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 200,
                HeightRequest = 100
            };
        }
    }
}
