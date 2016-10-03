using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XamarinForms
{
    public class BaskervillesPage : ContentPage
    {
        public BaskervillesPage()
        {
            Content = new Label
            {
                Text = "\u2003" + //no space between the indent string and the next word
                    "Mr. Sherlock Holmes, who was usually very late in " +
                    "the mornings, save upon those not infrequent " +
                    "occasions when he was up all night, was seated at " +
                    "the breakfast table. I stood upon the hearth-rug " +
                    "and picked up the stick which our visitor had left " +
                    "behind him the night before. It was a fine, thick " +
                    "piece of wood, bulbous-headed, of the sort which " +
                    "is known as a \u201CPenang lawyer.\u201D Just " +
                    "under the head was a broad silver band, nearly an " +
                    "inch across, \u201CTo James Mortimer, M.R.C.S., " +
                    "from his friends of the C.C.H.,\u201D was engraved " +
                    "upon it, with the date \u201C1884.\u201D It was " +
                    "just such a stick as the old-fashioned family " +
                    "practitioner used to carry\u2014dignified, solid, " +
                    "and reassuring.",
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                //HorizontalOptions = LayoutOptions.Center,
                //VerticalOptions = LayoutOptions.Center, // so that only that only the background of the label and not the entire page will have a background of yellow
                TextColor = Color.Blue,
                BackgroundColor = Color.Yellow,
            };

            Padding = new Thickness(5, Device.OnPlatform(5, 5, 20), 5, 5);

            /*
             There is no property to specify a first-line indent for the paragraph, but you can add one of your own with space characters of various types, 
             such as the em space (Unicode \u2003).
             */
            /*
                But setting the HorizontalTextAlignment property of the Label has a much more profound effect: 
                Setting this property affects the alignment of the individual lines. 
                A setting of TextAlign-ment.Center will center all the lines of the paragraph, and TextAlignment.
                Right aligns them all at the right. You can use HorizontalOptions in addition to HorizontalTextAlignment to shift the entire paragraph slightly to the center or the right.
                
                However, after you’ve set VerticalOptions to Start, Center, or End, any setting of Vertical-TextAlignment has no effect.
             */
        }
    }
}
