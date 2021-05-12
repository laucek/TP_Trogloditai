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
                FontSize = 30,
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
                    Text = "Padarykit edit buttona kam reiks, hf"
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
            EnterButton.Clicked += async (sender, args) => EnterButtonOnClick(sender, args, selectedComp);

            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label { Text = selectedComp.Name, HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        new Label { Text = $"Created by: {selectedComp.Name}", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        new Label { Text = $"{selectedComp.Description}", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        new Label { Text = $"Total tasks: {tasks.Count}", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        FavoriteButton,
                        editButton,
                        EnterButton,
                        new Label { Text = $"Comments:", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        commentEntry,
                        PostCommentButton


                    }
                }
            };

            Content = scrollView;
        }

        private void EnterButtonOnClick(object sender, EventArgs e, Competition selectedCom)
        {
            //To enter page
            return;
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
