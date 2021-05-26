using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1.Assets;
using System.Linq;
using App1.Repos;

namespace App1
{
    class ProfileDetails : ContentPage
    {
        public ProfileDetails()
        {
            CompetitionRepos compet = new CompetitionRepos();

            User creator = MySQLManager.LoadUsers().Where(x => x.id == Session.Id).FirstOrDefault();
            int total = compet.getTotalCompetitionCount(Session.Id);

            Button editButton = new Button();


            TaskRepos rep = new TaskRepos();

            editButton.IsVisible = false;

            if (creator.id == Session.Id)
            {
                editButton = new Button()
                {
                    IsVisible = true,
                    Text = "Edit",
                    BackgroundColor = Color.White,
                    BorderColor = Color.Black,
                    BorderWidth = 3,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                };
            }

            editButton.Clicked += async (sender, args) => await EditButtonClick(sender, args, editButton);


            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label { Text = "Profile details: " , HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        new Label { Text = $"Username: {creator.username}", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand }, //cia pakeisti i user username
                        new Label { Text = $"Email: {creator.email}", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        new Label { Text = $"First name: {creator.first_name}", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        new Label { Text = $"Registration date: {creator.registration_date}", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        new Label { Text = $"Total competitions created: {total}", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        editButton
                    }
                }
            };

            Content = scrollView;
        }

        private async System.Threading.Tasks.Task EditButtonClick(object sender, EventArgs e, Button button)
        {
            await Navigation.PushAsync(new EditAccount());
        }


    }

}
