using App1.Assets;
using App1.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace App1
{
    class CompetitionTasksList : ContentPage
    {
        Label Label;
        public CompetitionTasksList(int ind , Competition competition)
        {
            Button editButton = new Button();
            editButton.IsVisible = false;
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
            Button butt = new Button
            {
                Text = "Next page",
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 3,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Label = new Label
            {
                IsVisible = false,
                TextColor = Color.Red,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            TaskRepos rep = new TaskRepos();
            List<Assets.Task> tasks = rep.getTasks(competition.Id);


            Button task1 = new Button();
            Button task2 = new Button();
            Button task3 = new Button();
            Button task4 = new Button();
            Button task5 = new Button();

            task1.IsVisible = false;
            task2.IsVisible = false;
            task3.IsVisible = false;
            task4.IsVisible = false;
            task5.IsVisible = false;


            if (tasks.Count >= ind * 5 + 1)
            {
                task1 = new Button()
                {
                    IsVisible = true,
                    Text = $"{tasks[ind * 5].TaskName}",
                    BackgroundColor = Color.White,
                    BorderColor = Color.Black,
                    BorderWidth = 3,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    WidthRequest = 250
                };
            }
            if (tasks.Count >= ind * 5 + 2)
            {
                task2 = new Button()
                {
                    IsVisible = true,
                    Text = $"{tasks[ind * 5 + 1].TaskName}",
                    BackgroundColor = Color.White,
                    BorderColor = Color.Black,
                    BorderWidth = 3,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    WidthRequest = 250
                };
            }
            if (tasks.Count >= ind * 5 + 3)
            {
                task3 = new Button()
                {
                    IsVisible = true,
                    Text = $"{tasks[ind * 5 + 2].TaskName}",
                    BackgroundColor = Color.White,
                    BorderColor = Color.Black,
                    BorderWidth = 3,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    WidthRequest = 250
                };
            }
            if (tasks.Count >= ind * 5 + 4)
            {
                task4 = new Button()
                {
                    IsVisible = true,
                    Text = $"{tasks[ind * 5 + 3].TaskName}",
                    BackgroundColor = Color.White,
                    BorderColor = Color.Black,
                    BorderWidth = 3,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    WidthRequest = 250
                };
            }
            if (tasks.Count >= ind * 5 + 5)
            {
                task5 = new Button()
                {
                    IsVisible = true,
                    Text = $"{tasks[ind * 5 + 4].TaskName}",
                    BackgroundColor = Color.White,
                    BorderColor = Color.Black,
                    BorderWidth = 3,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    WidthRequest = 250
                };
            }

            bool allow = task1.IsVisible && task2.IsVisible && task3.IsVisible && task4.IsVisible && task5.IsVisible;

            task1.Clicked += async (sender, args) => await GoToEditTask(sender, args, tasks[0 * ind], competition);
            task2.Clicked += async (sender, args) => await GoToEditTask(sender, args, tasks[1 * ind], competition);
            task3.Clicked += async (sender, args) => await GoToEditTask(sender, args, tasks[2 * ind], competition);
            task4.Clicked += async (sender, args) => await GoToEditTask(sender, args, tasks[3 * ind], competition);
            task5.Clicked += async (sender, args) => await GoToEditTask(sender, args, tasks[4 * ind], competition);

            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label { Text = "Tasks list", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        Label,
                        task1,
                        task2,
                        task3,
                        task4,
                        task5,
                        butt
                    }
                }
            };

            Content = scrollView;
        }

        async System.Threading.Tasks.Task GoToEditTask(object sender, EventArgs args, Assets.Task comp, Competition competition)
        {
            await Navigation.PushAsync(new EditTask(comp, competition));
        }
        
        public bool allCompetitions()
        {
            TaskRepos rep = new TaskRepos();
            List<Assets.Task> tasks = rep.getTasks();
            if (tasks.Count() > 0)
            {
                foreach (var item in tasks)
                {
                    Label.Text += item.TaskName + "\n";
                }
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
