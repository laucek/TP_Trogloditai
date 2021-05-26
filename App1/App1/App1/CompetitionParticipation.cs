using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1.Assets;
using System.Linq;
using App1.Repos;
using Xamarin.Forms.Maps;
using System.Threading;

namespace App1
{
    class CompetitionParticipation : ContentPage
    {
        public CompetitionParticipation(ParticipationObject PO)
        {
            DateTime taskStart = DateTime.Now;

            Xamarin.Forms.Maps.Map map = new Xamarin.Forms.Maps.Map();

            Random rnd = new Random();
            int rndindex = rnd.Next(0, PO.Tasks.Count);
            Task currTask = PO.Tasks[rndindex];
            PO.Tasks.RemoveAt(rndindex);

            Label taskName = new Label()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = $"Task: {currTask.TaskName}"
            };

            Label desc = new Label()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = $"{currTask.Description}"
            };

            Label quest = new Label()
            {
                IsVisible = false,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = $"{currTask.Question}"
            };


            Button SubmitButt = new Button()
            {
                Text = "Submit",
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 3,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            Entry answerEntry = new Entry()
            {
                IsVisible = false,
                Placeholder = "Your answer here",
                BackgroundColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            map.HeightRequest = 300;

            var pos = new Position(lat, lon);
            MapSpan mapspan = new MapSpan(pos, 0.01, 0.01);
            map = new Xamarin.Forms.Maps.Map(mapspan);

            SubmitButt.Clicked += async (sender, args) => await SubmitButtonOnClick(sender, args, PO, currTask, taskStart, answerEntry);


            StackLayout C = new StackLayout();
            C.Children.Add(taskName);
            C.Children.Add(desc);
            C.Children.Add(map);
            C.Children.Add(answerEntry);
            C.Children.Add(quest);
            C.Children.Add(SubmitButt);

            WaitUntillInLocation(answerEntry, quest);

            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = C
            };
            Content = scrollView;

        }

        CancellationTokenSource cts;
        double lat=54.8985;
        double lon=23.9036;

        private async System.Threading.Tasks.Task WaitUntillInLocation(Entry entr, Label quest)
        {
            await System.Threading.Tasks.Task.Delay(6000);
            entr.IsVisible = true;
            quest.IsVisible = true;
        }

        private async System.Threading.Tasks.Task SubmitButtonOnClick(object sender, EventArgs e, ParticipationObject PO, Task task, DateTime startDate, Entry answerEntry)
        {
            DateTime endDate = DateTime.Now;
            TimeSpan ts = endDate - startDate;

            int score = 0;
            if (answerEntry.Text == task.Answer)
                score += 150;

            if(ts.TotalSeconds < 600)
            {
                double t = (600 - ts.TotalSeconds) / 600;
                score += (int)((double)score * (0.3 * t));
            }

            if(PO.Tasks.Count > 0)
            {
                await Navigation.PushAsync(new CompetitionParticipationTaskRes(PO, task, score));
            }
            else
            {
                await Navigation.PushAsync(new CompetitionParticipationResult(PO));
            }

        }

    }

}
