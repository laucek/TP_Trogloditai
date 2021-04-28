using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace App1
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            Button settings = new Button
            {
                Text = "Settings",
                //FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Button)),
                FontSize = 5,
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 1
            };

            Button competitionList = new Button
            {
                Text = "Competitions",
                FontSize = 5,
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Start
            };

            Button competitionCreate = new Button
            {
                Text = "New competition",
                FontSize = 5,
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 1
            };

            Button profile = new Button
            {
                Text = "Profile",
                FontSize = 5,
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.End
            };

            var image = new Image { Source = "image.jpg" };

            Grid grid = new Grid
            {
                ColumnSpacing = 0,
                RowDefinitions =
                {
                    new RowDefinition(),
                    new RowDefinition { Height = new GridLength(55) }
                },
                ColumnDefinitions =
                {
                    //new ColumnDefinition()
                }
            };

            grid.Children.Add(image, 0, 4, 0, 1);
            grid.Children.Add(competitionList, 0, 1, 1, 2);
            grid.Children.Add(competitionCreate, 1, 2, 1, 2);
            grid.Children.Add(settings, 2, 3, 1, 2);
            grid.Children.Add(profile, 3, 4, 1, 2);

            Content = grid;

            competitionList.Clicked += async (sender, args) => NavigateButton_OnClickedCompetitionList(sender, args, competitionList);
            competitionCreate.Clicked += async (sender, args) => NavigateButton_OnClickedCompetitionCreation(sender, args, competitionCreate);
            settings.Clicked += async (sender, args) => NavigateButton_OnClickedSettings(sender, args, settings);
            profile.Clicked += async (sender, args) => NavigateButton_OnClickedProfile(sender, args, profile);

        }

        private async void NavigateButton_OnClickedCompetitionList(object sender, EventArgs e, Button competitionList)
        {
            await Navigation.PushAsync(new CompetitionList());
        }

        private async void NavigateButton_OnClickedCompetitionCreation(object sender, EventArgs e, Button competitionCreate)
        {
            await Navigation.PushAsync(new CompetitionCreation());
        }

        private async void NavigateButton_OnClickedSettings(object sender, EventArgs e, Button settings)
        {
            await Navigation.PushAsync(new Settings());
        }

        private async void NavigateButton_OnClickedProfile(object sender, EventArgs e, Button profile)
        {
            await Navigation.PushAsync(new Profile());
        }
    }
}
