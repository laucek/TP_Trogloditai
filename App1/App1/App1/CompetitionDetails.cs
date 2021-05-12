using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1.Assets;

namespace App1
{
    class CompetitionDetails : ContentPage
    {
        public CompetitionDetails(Competition selectedComp)
        {
            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label { Text = "Competition details", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand }

                    }
                }
            };

            Content = scrollView;
        }
    }
}
