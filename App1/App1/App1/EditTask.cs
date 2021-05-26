using App1.Assets;
using App1.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1
{
    class EditTask : ContentPage
    {
        Label errorLabel;
        Entry eventName;

        public EditTask(Task selectedComp, Competition competition)
        {
           
            Button butt = new Button
            {
                Text = "Change Task settings",
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 3,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            eventName = new Entry
            {
                Text = selectedComp.TaskName,
                Placeholder = "Atleast 3 characters",
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

         
            butt.Clicked += async (sender, args) => await NavigateButton_OnClickedInEditTaskAsync(sender, args, butt, selectedComp, competition);

            ScrollView scrollView = new ScrollView
            {
                Content = new StackLayout
                {
                    Children = {

                    new Label { Text = "Change account info", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.StartAndExpand },
                        //First name
					    new Label { Text = "Task name: *", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        eventName,

                        butt,
                        errorLabel
                    }
                }
            };
            Content = scrollView;

        }


        private async System.Threading.Tasks.Task NavigateButton_OnClickedInEditTaskAsync(object sender, EventArgs e, Button butt, Task selectedComp, Competition competit)
        {
            if (Crit())
            {
                Task comp = new Task(selectedComp.id, eventName.Text, selectedComp.Description, selectedComp.latitude, selectedComp.longitude, 
                    selectedComp.Question, selectedComp.Answer, selectedComp.fk_Competition_id);
                TaskRepos compet = new TaskRepos();
                compet.updateTask(comp);
                ;
                await Navigation.PushAsync(new CompetitionTasksList(0, competit));
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
                if (eventName.Text.Length >= 3 )
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
