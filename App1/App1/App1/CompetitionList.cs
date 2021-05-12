using App1.Assets;
using App1.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace App1
{
    public class CompetitionList : ContentPage
    {
        Label Label;
        public CompetitionList()
        {
            Button seeLive = new Button
            {
                Text = "Peržiūrėti aktyvius",
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 3,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Button butt = new Button
            {
                Text = "Peržiūrėti visus",
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


            seeLive.Clicked += async (sender, args) => NavigateButton_OnClickedInLogin(sender, args, seeLive);
            butt.Clicked += async (sender, args) => NavigateButton_OnClickedInAllComps(sender, args, butt);

            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label { Text = "Competitions list", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        Label,
                        seeLive,
                        butt
                    }
                }
            };

            Content = scrollView;
        }

        private void NavigateButton_OnClickedInLogin(object sender, EventArgs e, Button seeLive)
        {

            if (list())
            {
                Label.IsVisible = true;
                seeLive.Text = "Visi aktyvūs";
            }
            else
            {
                Label.IsVisible = true;
            }

        }
        private void NavigateButton_OnClickedInAllComps(object sender, EventArgs e, Button butt)
        {

            if (allCompetitions())
            {
                Label.IsVisible = true;
                butt.Text = "Visi competitionai";
            }
            else
            {
                Label.IsVisible = true;
            }

        }

        public bool list()
        {
            CompetitionRepos rep = new CompetitionRepos();
            List<Competition> comps = rep.getCompetition();
            if(comps.Count() > 0)
            {
                foreach (var item in comps)
                {
                    if(item.StartDate < DateTime.Now && DateTime.Now < item.EndDate)
                    {
                        Label.Text += item.Name + "  ----  " + item.StartDate.ToString("yyyy-MM-dd") + "  ----  " + item.EndDate.ToString("yyyy-MM-dd") + "\n";
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
            
        }


        public bool allCompetitions()
        {
            CompetitionRepos rep = new CompetitionRepos();
            List<Competition> comps = rep.getCompetition();
            if (comps.Count() > 0)
            {
                foreach (var item in comps)
                {
                    Label.Text += item.Name + "  ----  " + item.StartDate.ToString("yyyy-MM-dd") + "  ----  " + item.EndDate.ToString("yyyy-MM-dd") + "\n";
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
