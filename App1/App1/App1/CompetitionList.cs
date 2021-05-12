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
    public class CompetitionList : ContentPage
    {
        Label Label;
        public CompetitionList(int ind = 0, int sortIndex = -1)
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
                Text = "Next page",
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 3,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            CompetitionRepos rep = new CompetitionRepos();
            List<Competition> comps = rep.getCompetition();
            switch (sortIndex)
            {
                case 0:
                    comps = comps.OrderByDescending(i => i.Name).ToList();
                    break;
                case 1:
                    comps = comps.OrderBy(i => i.Name).ToList();
                    break;
                case 2:
                    comps = comps.OrderByDescending(i => i.StartDate).ToList();
                    break;
                case 3:
                    comps = comps.OrderBy(i => i.StartDate).ToList();
                    break;
                default:
                    break;
            }

            Button competition1 = new Button();
            Button competition2 = new Button();
            Button competition3 = new Button();
            Button competition4 = new Button();
            Button competition5 = new Button();

            competition1.IsVisible = false;
            competition2.IsVisible = false;
            competition3.IsVisible = false;
            competition4.IsVisible = false;
            competition5.IsVisible = false;


            if(comps.Count >= ind * 5 + 1)
            {
                competition1 = new Button()
                {
                    IsVisible = true,
                    Text = $"{comps[ind * 5].Name}",
                    BackgroundColor = Color.White,
                    BorderColor = Color.Black,
                    BorderWidth = 3,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    WidthRequest = 250
                };
            }
            if(comps.Count >= ind * 5 + 2)
            {
                competition2 = new Button()
                {
                    IsVisible = true,
                    Text = $"{comps[ind * 5 + 1].Name}",
                    BackgroundColor = Color.White,
                    BorderColor = Color.Black,
                    BorderWidth = 3,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    WidthRequest = 250
                };
            }
            if(comps.Count >= ind * 5 + 3)
            {
                competition3 = new Button()
                {
                    IsVisible = true,
                    Text = $"{comps[ind * 5 + 2].Name}",
                    BackgroundColor = Color.White,
                    BorderColor = Color.Black,
                    BorderWidth = 3,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    WidthRequest = 250
                };
            }
            if(comps.Count >= ind * 5 + 4)
            {
                competition4 = new Button()
                {
                    IsVisible = true,
                    Text = $"{comps[ind * 5 + 3].Name}",
                    BackgroundColor = Color.White,
                    BorderColor = Color.Black,
                    BorderWidth = 3,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    WidthRequest = 250
                };
            }
            if(comps.Count >= ind * 5 + 5)
            {
                competition5 = new Button()
                {
                    IsVisible = true,
                    Text = $"{comps[ind * 5 + 4].Name}",
                    BackgroundColor = Color.White,
                    BorderColor = Color.Black,
                    BorderWidth = 3,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    WidthRequest = 250
                };
            }
            
            Label = new Label
            {
                IsVisible = false,
                TextColor = Color.Red,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var criteriaList = new List<string>();
            criteriaList.Add("Name Descending");
            criteriaList.Add("Name Ascending");
            criteriaList.Add("Start Date Descending");
            criteriaList.Add("Start Date Ascending");

            Picker picker = new Picker
            {
                Title = "Sort Competitions",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            picker.ItemsSource = criteriaList;

            //seeLive.Clicked += async (sender, args) => NavigateButton_OnClickedInLogin(sender, args, seeLive);

            bool allow = competition1.IsVisible && competition2.IsVisible && competition3.IsVisible && competition4.IsVisible && competition5.IsVisible;

            butt.Clicked += async (sender, args) => await NavigateButton_OnClickedInAllComps(sender, args, ind, allow, sortIndex);

            picker.SelectedIndexChanged += (sender, args) => NavigatePicker_OnClickedInAllComps(picker);

            competition1.Clicked += async (sender, args) => await GoToCompetitonDetails(sender, args, comps[0 * ind]);
            competition2.Clicked += async (sender, args) => await GoToCompetitonDetails(sender, args, comps[1 * ind]);
            competition3.Clicked += async (sender, args) => await GoToCompetitonDetails(sender, args, comps[2 * ind]);
            competition4.Clicked += async (sender, args) => await GoToCompetitonDetails(sender, args, comps[3 * ind]);
            competition5.Clicked += async (sender, args) => await GoToCompetitonDetails(sender, args, comps[4 * ind]);

            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label { Text = "Competitions list", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        Label,
                        competition1,
                        competition2,
                        competition3,
                        competition4,
                        competition5,
                        butt,
                        picker
                    }
                }
            };
            
            Content = scrollView;
        }

        async System.Threading.Tasks.Task GoToCompetitonDetails(object sender, EventArgs args, Competition comp)
        {
            await Navigation.PushAsync(new CompetitionDetails(comp));
        }

        private void NavigatePicker_OnClickedInAllComps(Picker picker)
        {
            if (picker.SelectedIndex == 0)
            {
                Navigation.PushAsync(new CompetitionList(0, 0));
            }
            if (picker.SelectedIndex == 1)
            {
                Navigation.PushAsync(new CompetitionList(0, 1));
            }
            if (picker.SelectedIndex == 2)
            {
                Navigation.PushAsync(new CompetitionList(0, 2));
            }
            if (picker.SelectedIndex == 3)
            {
                Navigation.PushAsync(new CompetitionList(0, 3));
            }
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
        async System.Threading.Tasks.Task NavigateButton_OnClickedInAllComps(object sender, EventArgs e, int i, bool allow, int sortIndex)
        {
            if(allow)
                await Navigation.PushAsync(new CompetitionList(i + 1, sortIndex));
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
