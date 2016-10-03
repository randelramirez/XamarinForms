using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XamarinForms
{
    public class FitToSizeClockPage : ContentPage
    {
        public FitToSizeClockPage()
        {
            Label clockLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            Content = clockLabel;

            /*
                Many C# programmers these days like to define small event handlers as anonymous lambda func-tions. 
                This allows the event-handling code to be very close to the instantiation and initialization of the object firing the event 
                instead of somewhere else in the file. It also allows referencing objects within the event handler without storing those objects as fields.
             */

            // Handle the SizeChanged event for the page.
            SizeChanged += (object sender, EventArgs args) =>
            {
                // Scale the font size to the page width
                //      (based on 11 characters in the displayed string).
                if (this.Width > 0)
                    clockLabel.FontSize = this.Width / 6;
            };

            // Start the timer going.
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                // Set the Text property of the Label.
                clockLabel.Text = DateTime.Now.ToString("h:mm:ss tt");
                return true;
            });
        }
    }
}
