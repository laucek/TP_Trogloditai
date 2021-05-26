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
    class CompetitionParticipationTaskRes : ContentPage
    {
        public CompetitionParticipationTaskRes(ParticipationObject PO, Task currTask, int score)
        {
            PO.Score += score;
            
            Label taskName = new Label()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = $"Task: {currTask.TaskName}"
            };

            Label gained = new Label()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = $"Score gained: +{score} pts"
            };

            Label total = new Label()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = $"Total score: {PO.Score}"
            };

            Button SubmitButt = new Button()
            {
                Text = "Next",
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 3,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            SubmitButt.Clicked += async (sender, args) => await NextButtonClick(sender, args, PO);

            StackLayout C = new StackLayout();
            C.Children.Add(taskName);
            C.Children.Add(gained);
            C.Children.Add(total);
            C.Children.Add(SubmitButt);


            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = C
            };
            Content = scrollView;

        }


        private async System.Threading.Tasks.Task NextButtonClick(object sender, EventArgs e, ParticipationObject PO)
        {
            await Navigation.PushAsync(new CompetitionParticipation(PO));
        }

    }

}
