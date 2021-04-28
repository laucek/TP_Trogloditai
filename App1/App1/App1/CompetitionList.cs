using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1
{
    public class CompetitionList : ContentPage
    {
        public CompetitionList()
        {
            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = new StackLayout
                {
                    Children =
                    {
					    new Label { Text = "Competitions list", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand }

                    }
                }
            };

            Content = scrollView;
        }
    }
}
