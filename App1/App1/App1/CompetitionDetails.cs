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
            Button competitionList = new Button
            {
                Text = "Competitions",
                FontSize = 5,
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Start
            };
            competitionList.Clicked += async (sender, args) => NavigateButton_OnClickedCompetitionList(sender, args, selectedComp);
            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label { Text = "Competition details", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        competitionList
                    }
                }
            };

            Content = scrollView;
        }


        private async void NavigateButton_OnClickedCompetitionList(object sender, EventArgs e, Competition selectedComp)
        {
            await Navigation.PushAsync(new EditCompetition(selectedComp));
        }
    }
}
