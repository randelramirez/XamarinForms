using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XamarinForms
{
    public class MonkeyTapUsingCodePage : ContentPage
    {
        const int sequenceTime = 750;       // in msec
        protected const int flashDuration = 250;

        const double offLuminosity = 0.4;   // somewhat dimmer
        const double onLuminosity = 0.75;   // much brighter


        BoxView boxview0 = new BoxView { VerticalOptions = LayoutOptions.FillAndExpand };
        BoxView boxview1 = new BoxView { VerticalOptions = LayoutOptions.FillAndExpand };
        BoxView boxview2 = new BoxView { VerticalOptions = LayoutOptions.FillAndExpand };
        BoxView boxview3 = new BoxView { VerticalOptions = LayoutOptions.FillAndExpand };
        BoxView[] boxviews;
        Button startGameButton;
        Color[] colors = { Color.Red, Color.Blue, Color.Yellow, Color.Green };
        List<int> sequence = new List<int>();
        int sequenceIndex;
        bool awaitingTaps;
        bool gameEnded;
        Random random = new Random();

        public MonkeyTapUsingCodePage()
        {
            var stackLayout = new StackLayout();
            boxviews =  new BoxView[] { boxview0, boxview1, boxview2, boxview3 };
            startGameButton = new Button
            {
                Text = "Begin",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.Center,
                
            };
            startGameButton.Clicked += OnStartGameButtonClicked;

            stackLayout.Children.Add(boxviews[0]);
            stackLayout.Children.Add(boxviews[1]);
            stackLayout.Children.Add(startGameButton);
            stackLayout.Children.Add(boxviews[2]);
            stackLayout.Children.Add(boxviews[3]);


            foreach (var boxview in boxviews)
            {
                
                TapGestureRecognizer tapGesture = new TapGestureRecognizer();
                tapGesture.Tapped += OnBoxViewTapped;
                boxview.GestureRecognizers.Add(tapGesture);
            }

            Content = stackLayout;

        }

        void InitializeBoxViewColors()
        {
            for (int index = 0; index < 4; index++)
                boxviews[index].Color = colors[index].WithLuminosity(offLuminosity);
        }

        protected void OnStartGameButtonClicked(object sender, EventArgs args)
        {
            gameEnded = false;
            startGameButton.IsVisible = false;
            InitializeBoxViewColors();
            sequence.Clear();
            StartSequence();
        }

        void StartSequence()
        {
            sequence.Add(random.Next(4));
            sequenceIndex = 0;
            Device.StartTimer(TimeSpan.FromMilliseconds(sequenceTime), OnTimerTick);
        }

        bool OnTimerTick()
        {
            if (gameEnded)
                return false;

            FlashBoxView(sequence[sequenceIndex]);
            sequenceIndex++;
            awaitingTaps = sequenceIndex == sequence.Count;
            sequenceIndex = awaitingTaps ? 0 : sequenceIndex;
            return !awaitingTaps;
        }

        protected virtual void FlashBoxView(int index)
        {
            boxviews[index].Color = colors[index].WithLuminosity(onLuminosity);
            Device.StartTimer(TimeSpan.FromMilliseconds(flashDuration), () =>
            {
                if (gameEnded)
                    return false;

                boxviews[index].Color = colors[index].WithLuminosity(offLuminosity);
                return false;
            });
        }

        protected void OnBoxViewTapped(object sender, EventArgs args)
        {
            if (gameEnded)
                return;

            if (!awaitingTaps)
            {
                EndGame();
                return;
            }

            BoxView tappedBoxView = (BoxView)sender;
            int index = Array.IndexOf(boxviews, tappedBoxView);

            if (index != sequence[sequenceIndex])
            {
                EndGame();
                return;
            }

            FlashBoxView(index);

            sequenceIndex++;
            awaitingTaps = sequenceIndex < sequence.Count;

            if (!awaitingTaps)
                StartSequence();
        }

        protected virtual void EndGame()
        {
            gameEnded = true;

            for (int index = 0; index < 4; index++)
                boxviews[index].Color = Color.Gray;

            startGameButton.Text = "Try again?";
            startGameButton.IsVisible = true;
        }
    }
}
