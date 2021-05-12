using App1.Assets;
using App1.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1
{
    class EditCompetition : ContentPage
    {
        Entry eventName;
        DatePicker startDate;
        DatePicker endDate;
        Entry description;
        Picker LiveType;
        Label errorLabel;


        public EditCompetition(Competition selectedComp)
        {
            Button butt = new Button
            {
                Text = "Change settings",
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 3,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };


            eventName = new Entry
            {
                Text = "Event name",
                Placeholder = "Atleast 3 characters",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            startDate = new DatePicker
            {
                Date = DateTime.Now,
                MinimumDate = DateTime.Now,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            endDate = new DatePicker
            {
                Date = DateTime.Now.AddDays(50),
                MinimumDate = DateTime.Now,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            description = new Entry
            {
                
                Text = selectedComp.Description,
                Placeholder = "Describe your competition",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            LiveType = new Picker
            {
                WidthRequest = 100,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            errorLabel = new Label
            {
                IsVisible = false,
                Text = "Something went wrong, check your credentials: \nAny field can not be empty\nName and Username should be at least 4 digits long\nPassword must be at least 6 symbols long\n",
                TextColor = Color.Red,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            butt.Clicked += async (sender, args) => NavigateButton_OnClickedInEditComp(sender, args, butt, selectedComp);

            ScrollView scrollView = new ScrollView
            {
                Content = new StackLayout
                {
                    Children = {

                    new Label { Text = "Change account info", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.StartAndExpand },
                        //First name
					    new Label { Text = "Competition name: *", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        eventName,

                        //User name
                        new Label { Text = "Start date: *", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        startDate,

                        //Email
                        new Label { Text = "End date: *", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        endDate,


                        //Password
                        new Label { Text = "Descriotion: *", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        description,

                        //Password confirmation
                        new Label { Text = "LiveType: *", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        LiveType,

                        butt,
                        errorLabel
                    }
                }
            };
            Content = scrollView;

        }


        private void NavigateButton_OnClickedInEditComp(object sender, EventArgs e, Button butt, Competition selectedComp)
        {
            if (Crit())
            {
                int type = 1;
                Competition comp = new Competition(selectedComp.Id, eventName.Text, startDate.Date, endDate.Date,description.Text, type, selectedComp.fk_CreatorId);
                CompetitionRepos compet = new CompetitionRepos();
                compet.updateCompetition(comp);
                butt.Text = eventName.Text;
            }
            else
            {
                errorLabel.IsVisible = true;
            }

        }
        bool Crit()
        {
            try
            {
                if (eventName.Text.Length >= 3  && description.Text.Length >= 5)
                {
                    return true;
                }
                return false;

            }
            catch
            {
                return false;
            }
        }
    }
}
