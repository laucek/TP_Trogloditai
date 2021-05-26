using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1.Assets;
using System.Linq;
using App1.Repos;

namespace App1
{
    class CompetitionDetails : ContentPage
    {
        public CompetitionDetails(Competition selectedComp)
        {
            User creator = MySQLManager.LoadUsers().Where(x => x.id == selectedComp.fk_CreatorId).FirstOrDefault();
            Button FavoriteButton = new Button
            {
                Text = "☆",
                HeightRequest = 50,
                WidthRequest = 50,
                FontSize = 25,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                TextColor = Color.Yellow,
                BackgroundColor = Color.LightGray
                
            };

            Button editButton = new Button();
            Button EnterButton = new Button();
            

            TaskRepos rep = new TaskRepos();
            List<Task> tasks = rep.getTasks(selectedComp.Id);

            editButton.IsVisible = false;
            EnterButton.IsVisible = false;

            if(creator.id == Session.Id)
            {
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
            }
            else
            {
                EnterButton = new Button()
                {
                    IsVisible = true,
                    Text = "Enter",
                    BackgroundColor = Color.White,
                    BorderColor = Color.Black,
                    BorderWidth = 3,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                };
            }

            Entry commentEntry = new Entry()
            {
                IsVisible = false,
                BackgroundColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 200,
                HeightRequest = 200
            };

            Button PostCommentButton = new Button()
            {
                Text = "Post",
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 3,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            if (isFavorited(selectedComp))
            {
                FavoriteButton.BackgroundColor = Color.Orange;
            }

            FavoriteButton.Clicked += async (sender, args) => FavoriteButtonOnClick(sender, args, FavoriteButton, selectedComp);
            PostCommentButton.Clicked += async (sender, args) => PostCommentOnClick(sender, args, commentEntry, selectedComp);
            EnterButton.Clicked += async (sender, args) => await EnterButtonOnClick(sender, args, selectedComp);
            editButton.Clicked += async (sender, args) => await EditButtonClick(sender, args, editButton, selectedComp);
            List<User> users = MySQLManager.LoadUsers();
            User usr = users.Where(x => x.id == selectedComp.fk_CreatorId).FirstOrDefault();

            StackLayout C = new StackLayout();
            C.Children.Add(new Label { Text = selectedComp.Name, HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand });
            C.Children.Add(new Label { Text = $"Created by: {usr.username}", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand });
            C.Children.Add(new Label { Text = $"{selectedComp.Description}", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand });
            C.Children.Add(new Label { Text = $"Total tasks: {tasks.Count}", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand });
            C.Children.Add(FavoriteButton);
            C.Children.Add(editButton);
            C.Children.Add(EnterButton);
            C.Children.Add(new Label { Text = $"Comments:", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand });
            C.Children.Add(commentEntry);
            C.Children.Add(PostCommentButton);

            List<Comment> comments = MySQLManager.LoadCommentByCompetition(selectedComp.Id);



            foreach (var item in comments)
            {
                try
                {
                    C.Children.Add(new Label
                    {
                        Text = $"{users.Where(x => x.id == item.fk_Usersid).FirstOrDefault().username}:{comments.Count}\n" +
                    $"{item.Commentaras}\n{item.Date}",
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        WidthRequest = 200,
                        HeightRequest = 150
                    });
                }
                catch
                {
                    continue;
                }
                
            }

            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = C
            };

            Content = scrollView;
        }

        private async System.Threading.Tasks.Task EnterButtonOnClick(object sender, EventArgs e, Competition selectedCom)
        {
            //To enter page
            return;
        }
        
        private async System.Threading.Tasks.Task EditButtonClick(object sender, EventArgs e, Button button, Competition selectedCom)
        {
            await Navigation.PushAsync(new EditCompetition(selectedCom));
        }

        private void FavoriteButtonOnClick(object sender, EventArgs e, Button button, Competition selectedCom)
        {
            FavoriteRepos favRep = new FavoriteRepos();

            if (isFavorited(selectedCom))
            {
                button.BackgroundColor = Color.Orange;
                MySQLManager.DeleteFavorite(new Favorite(0, selectedCom.Id, Session.Id));
                button.BackgroundColor = Color.LightGray;
            }
            else
            {
                Favorite fav = new Favorite(0, selectedCom.Id, Session.Id);
                MySQLManager.InsertFavorite(fav);
                button.BackgroundColor = Color.Orange;
            }

        }

        private void PostCommentOnClick(object sender, EventArgs e, Entry entry, Competition comp)
        {
            if (!entry.IsVisible)
            {
                entry.IsVisible = true;
                return;
            }
            else
            {
                if (meetsCommentCriteria(entry))
                {
                    //Post a comment
                    CommentRepos commentRep = new CommentRepos();
                    Comment com = new Comment(0, DateTime.Now, entry.Text, comp.Id, Session.Id);

                    try
                    {
                        MySQLManager.InsertComment(com);
                        entry.Text = "";
                        entry.IsVisible = false;
                        Navigation.PushAsync(new CompetitionDetails(comp));
                    }
                    catch
                    {
                        return;
                    }
                }
                else
                {
                    //error msg mby
                }
            }

        }

        bool meetsCommentCriteria(Entry entry)
        {
            if(entry.Text.Length > 1)
            {
                return true;
            }
            return false; ;
        }

        private bool isFavorited(Competition selectedComp)
        {
            FavoriteRepos rep = new FavoriteRepos();
            List<Favorite> fvs = MySQLManager.LoadFavs();

            foreach (var item in fvs)
            {
                if(item.fk_Competitionsid == selectedComp.Id && item.fk_Usersid == Session.Id)
                {
                    return true;
                }
            }

            return false;
        }
    }

}
