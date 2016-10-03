using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XamarinForms
{
    struct FontCalc
    {
        public FontCalc(Label label, double fontSize, double containerWidth)
            : this()
        {
            // Save the font size.
            FontSize = fontSize;

            /*
                When you make a call to GetSizeRequest on a page or a layout, the page or layout needs to ob-tain the sizes of all its children down through the visual tree. 
                This has a performance penalty, of course, so you should avoid making calls like that unless necessary. 
                But a Label has no children, so calling GetSizeRequest on a Label is not nearly as bad. 
                However, you should still try to optimize the calls. Avoid looping through a sequential series of font size values to determine the maximum value 
                that doesn’t result in text exceeding the container height. A process that algorithmically narrows in on an optimum value is better.

                GetSizeRequest requires that the element be part of a visual tree and that the layout process has at least partially begun. 
                Don’t call GetSizeRequest in the constructor of your page class. 
                You won’t get information from it. The first reasonable opportunity is in an override of the page’s OnAppearing method. 
                Of course, you might not have sufficient information at this time to pass arguments to the GetSizeRequest method.

                However, calling GetSizeRequest doesn’t have any side effects. It doesn’t cause a new size to be set on the element, 
                which means that it doesn’t cause a SizeChanged event to be fired, which means that it’s safe to call in a SizeChanged handler.
             */

            // Recalculate the Label height.
            label.FontSize = fontSize;
            SizeRequest sizeRequest =
                 //label.GetSizeRequest(containerWidth, Double.PositiveInfinity); //obsolete
                label.Measure(containerWidth, double.PositiveInfinity);

            // Save that height.
            TextHeight = sizeRequest.Request.Height;
        }

        public double FontSize { private set; get; }

        public double TextHeight { private set; get; }
    }

    public class EmpiricalFontSizePage : ContentPage
    {
        Label label;

        public EmpiricalFontSizePage()
        {
            label = new Label();

            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            ContentView contentView = new ContentView
            {
                Content = label
            };
            contentView.SizeChanged += OnContentViewSizeChanged;
            Content = contentView;
        }

        void OnContentViewSizeChanged(object sender, EventArgs args)
        {
            // Get View whose size is changing.
            View view = (View)sender;

            if (view.Width <= 0 || view.Height <= 0)
                return;

            label.Text =
                "This is a paragraph of text displayed with " +
                "a FontSize value of ?? that is empirically " +
                "calculated in a loop within the SizeChanged " +
                "handler of the Label's container. This technique " +
                "can be tricky: You don't want to get into " +
                "an infinite loop by triggering a layout pass " +
                "with every calculation. Does it work?";

            // Calculate the height of the rendered text.
            FontCalc lowerFontCalc = new FontCalc(label, 10, view.Width);
            FontCalc upperFontCalc = new FontCalc(label, 100, view.Width);

            while (upperFontCalc.FontSize - lowerFontCalc.FontSize > 1)
            {
                // Get the average font size of the upper and lower bounds.
                double fontSize = (lowerFontCalc.FontSize + upperFontCalc.FontSize) / 2;

                // Check the new text height against the container height.
                FontCalc newFontCalc = new FontCalc(label, fontSize, view.Width);

                if (newFontCalc.TextHeight > view.Height)
                {
                    upperFontCalc = newFontCalc;
                }
                else
                {
                    lowerFontCalc = newFontCalc;
                }
            }

            // Set the final font size and the text with the embedded value.
            label.FontSize = lowerFontCalc.FontSize;
            label.Text = label.Text.Replace("??", label.FontSize.ToString("F0"));
        }
    }
}
