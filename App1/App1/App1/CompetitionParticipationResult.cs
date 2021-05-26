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
    class CompetitionParticipationResult : ContentPage
    {
        public CompetitionParticipationResult(ParticipationObject PO)
        {            
            Label Congratz = new Label()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = $"You have completed the competition {PO.Competition.Name}"
            };

            Label gained = new Label()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = $"Your score is: {PO.Score}"
            };

            Button SubmitButt = new Button()
            {
                Text = "Back",
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 3,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            SubmitButt.Clicked += async (sender, args) => await NextButtonClick(sender, args, PO);

            StackLayout C = new StackLayout();
            C.Children.Add(Congratz);
            C.Children.Add(gained);
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
            await Navigation.PushAsync(new HomePage());
        }

    }

}
