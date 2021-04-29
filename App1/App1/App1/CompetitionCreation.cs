using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace App1
{
    public class competitionCreationSeed
    {
        public string eventName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string description { get; set; }
        public int LiveType { get; set; }
        public List<Assets.Task> Tasks { get; set; }

        public competitionCreationSeed()
        {
            this.eventName = null;
            this.startDate = DateTime.Now;
            this.endDate = DateTime.Now;
            this.description = null;
            LiveType = 2;
            Tasks = new List<Assets.Task>();
        }

        public competitionCreationSeed(string eventName, DateTime startDate, DateTime endDate, string description, string liveType)
        {
            this.eventName = eventName;
            this.startDate = startDate;
            this.endDate = endDate;
            this.description = description;
            if (liveType == "Yes")
            {
                LiveType = 1;
            }
            else
            {
                LiveType = 2;
            }
            Tasks = new List<Assets.Task>();
        }

        public void AddTask(Assets.Task task)
        {
            Tasks.Add(task);
        }

        public void SetLiveType(string l)
        {
            if (l == "Yes")
            {
                LiveType = 1;
            }
            else
            {
                LiveType = 2;
            }
        }
    }

    public class CompetitionCreation : ContentPage
    {

        Entry eventName;
        DatePicker startDate;
        DatePicker endDate;
        Entry description;
        Picker LiveType;

        Label TaskCount;

        Label errorLabel;
        Label errorLabel2;

        public CompetitionCreation(competitionCreationSeed seed)
        {
            
            Button CreationButton = new Button
            {
                Text = "Create",
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 3,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Button TaskAddButton = new Button
            {
                Text = "Add Task",
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 3,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            eventName = new Entry
            {
                Text = seed.eventName,
                Placeholder = "Atleast 3 characters",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            startDate = new DatePicker
            {
                Date = seed.startDate,
                MinimumDate = DateTime.Now,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            endDate = new DatePicker
            {
                Date = seed.endDate,
                MinimumDate = DateTime.Now,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            description = new Entry
            {
                Text = seed.description,
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
                Text = "Something went wrong, make sure your inputs meet the criteria",
                TextColor = Color.Red,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            errorLabel2 = new Label
            {
                IsVisible = false,
                Text = "This email is already registered",
                TextColor = Color.Red,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            TaskCount = new Label
            {
                Text = seed.Tasks.Count.ToString(),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            CreationButton.Clicked += async (sender, args) => await OnButtonClicked(sender, args, CreationButton, seed);
            TaskAddButton.Clicked += async (sender, args) => await OnTaskAdd(sender, args, TaskAddButton, seed);


            LiveType.Items.Add("Yes");
            LiveType.Items.Add("No");

            LiveType.SelectedIndex = seed.LiveType;

            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = new StackLayout
                {
                    Children =
                    {
					    new Label { Text = "Competition name:*", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        eventName,

                        new Label { Text = "Starting date:*", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        startDate,

                        new Label { Text = "Ending date (same as start for endless):", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        endDate,

                        new Label { Text = "Description:*", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        description,

                        new Label { Text = "Is this event Live?*", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        LiveType,

                        new Label { Text = "Task count:*", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        TaskCount,

                        TaskAddButton,
                        CreationButton,
                        errorLabel,
                        errorLabel2

                    }
                }
            };

            Content = scrollView;
        }

        async Task OnTaskAdd(object sender, EventArgs args, Button butt, competitionCreationSeed seed)
        {
            seed.eventName = eventName.Text;
            seed.startDate = startDate.Date;
            seed.endDate = endDate.Date;
            seed.description = description.Text;
            seed.SetLiveType(LiveType.SelectedItem.ToString());

            await Navigation.PushAsync(new TaskCreation(seed));
        }

        async Task OnButtonClicked(object sender, EventArgs args, Button butt, competitionCreationSeed seed)
        {
            if (!MeetsCriteria(seed))
            {
                errorLabel.IsVisible = true;
            }
            else
            {
                int type = LiveType.SelectedIndex;
                Assets.Competition comp = new Assets.Competition(0, eventName.Text, startDate.Date, endDate.Date, description.Text, type, Session.Id);
                int compIndex = MySQLManager.InsertCompetition(comp);
                 
                foreach (var item in seed.Tasks)
                {
                    item.fk_Competition_id = compIndex;
                    MySQLManager.InsertTask(item);
                }

                await Navigation.PushAsync(new HomePage());
            }
        }

        bool MeetsCriteria(competitionCreationSeed seed)
        {
            try
            {
                if (eventName.Text.Length >= 3 && description.Text.Length >= 6 && endDate.Date >= startDate.Date && seed.Tasks.Count >= 3)
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