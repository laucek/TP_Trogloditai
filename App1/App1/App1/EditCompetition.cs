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
                Text = selectedComp.Name,
                Placeholder = "Atleast 3 characters",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            startDate = new DatePicker
            {
                Date = selectedComp.StartDate,
                MinimumDate = DateTime.Now,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            endDate = new DatePicker
            {
                Date = selectedComp.EndDate,
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
                Text = "Something went wrong, check your credentials: \nAny field can not be empty\nEvent name should be at least 3 digits long\nEnding date can't be smaller than Starting date\n",
                TextColor = Color.Red,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            LiveType.Items.Add("Yes");
            LiveType.Items.Add("No");
            
            butt.Clicked += async (sender, args) => await NavigateButton_OnClickedInEditCompAsync(sender, args, butt, selectedComp);

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


        private async System.Threading.Tasks.Task NavigateButton_OnClickedInEditCompAsync(object sender, EventArgs e, Button butt, Competition selectedComp)
        {
            if (Crit())
            {
                int type = LiveType.SelectedIndex;
                Competition comp = new Competition(selectedComp.Id, eventName.Text, startDate.Date, endDate.Date, description.Text, type, selectedComp.fk_CreatorId);
                CompetitionRepos compet = new CompetitionRepos();
                compet.updateCompetition(comp);
                ;
                await Navigation.PushAsync(new CompetitionDetails(selectedComp));
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
                if (eventName.Text.Length >= 3 && description.Text.Length >= 5 && startDate.Date <= endDate.Date)
                {
                    if(LiveType.SelectedIndex != 1 || LiveType.SelectedIndex != 2)
                    {
                        LiveType.SelectedIndex = 2;
                    }
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
