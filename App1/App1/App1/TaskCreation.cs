using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

using Xamarin.Forms;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace App1
{
    public class TaskCreation : ContentPage
    {
        Entry taskName;
        Entry Description;
        Entry Question;
        Entry Answer;
        Label errorLabel;

        public TaskCreation(competitionCreationSeed seed)
        {
            Button butt = new Button
            {
                Text = "Add",
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 3,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            errorLabel = new Label
            {
                IsVisible = false,
                Text = "Something went wrong, check your credentials",
                TextColor = Color.Red,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            taskName = new Entry
            {
                Placeholder = "Enter task name",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Description = new Entry
            {
                Placeholder = "Describe the task",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            Question = new Entry
            {
                Placeholder = "Question",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            Answer = new Entry
            {
                Placeholder = "Correct answer",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            Map map = new Map();
            
            butt.Clicked += async (sender, args) => NavigateButton_OnClickedInLogin(sender, args, butt, seed, map);

            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label { Text = "Task Creation", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.StartAndExpand },
                        taskName,
                        Description,
                        Question,
                        Answer,
                        map,
                        butt,
                        errorLabel
                    }
                }
            };

            Content = scrollView;
        }

        private async void NavigateButton_OnClickedInLogin(object sender, EventArgs e, Button butt, competitionCreationSeed seed, Map map)
        {
            
            if (Crit())
            {
                seed.AddTask(GetTaskObject(map));
                await Navigation.PushAsync(new CompetitionCreation(seed));
            }
            else
            {
                errorLabel.IsVisible = true;
            }

        }

        Assets.Task GetTaskObject(Map map)
        {
            return new Assets.Task(0, taskName.Text, Description.Text, map.AnchorX, map.AnchorY, Question.Text, Answer.Text, 0);
        }

        bool Crit()
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}