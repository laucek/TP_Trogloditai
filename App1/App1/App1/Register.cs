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
    public class Register : ContentPage
    {

        Entry firstNameEntry;
        Entry username;
        Entry emailEntry;
        Entry password;
        Entry passwordconfirm;

        Label errorLabel;
        Label errorLabel2;

        public Register()
        {
            

            Button butt = new Button
            {
                Text = Session.Language.Registerstring,
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 3,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            firstNameEntry = new Entry
            {
                Placeholder = Session.Language.Atleast3CharsString,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            username = new Entry
            {
                Placeholder = Session.Language.Atleast3CharsString,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            emailEntry = new Entry
            {
                Placeholder = Session.Language.EnterEmailString,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            password = new Entry
            {
                IsPassword = true,
                Placeholder = Session.Language.Atleast3CharsString,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            passwordconfirm = new Entry
            {
                IsPassword = true,
                Placeholder = Session.Language.Atleast3CharsString,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            errorLabel = new Label
            {
                IsVisible = false,
                Text = Session.Language.RegisterErrorString,
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

            butt.Clicked += async (sender, args) => await OnButtonClicked(sender, args, butt);

            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = new StackLayout
                {
                    Children =
                    {
                        //First name
					    new Label { Text = Session.Language.FirstNameString, HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        firstNameEntry,

                        //User name
                        new Label { Text = Session.Language.UsernameString, HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        username,

                        //Email
                        new Label { Text = Session.Language.EmailString, HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        emailEntry,


                        //Password
                        new Label { Text = Session.Language.PasswordString, HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        password,

                        //Password confirmation
                        new Label { Text = Session.Language.PasswordConfirmString, HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        passwordconfirm,

                        butt,
                        errorLabel,
                        errorLabel2
                        
                    }
                }
            };

            Content = scrollView;
        }

        async Task OnButtonClicked(object sender, EventArgs args, Button butt)
        {
            if (!MeetsCriteria())
            {
                errorLabel.IsVisible = true;
            }
            else
            {

                User user = new User(0, username.Text, emailEntry.Text, password.Text, firstNameEntry.Text, DateTime.Now);

                if (!MeetsCriteria2(user))
                {
                    errorLabel2.IsVisible = true;
                    return;
                }

                butt.Text = MySQLManager.InsertUser(user);

                await Navigation.PushAsync(new Login());
            }

        }

        bool MeetsCriteria()
        {
            try
            {
                if (firstNameEntry.Text.Length >= 3 && username.Text.Length >= 3 && emailEntry.Text.Length >= 6 && emailEntry.Text.Contains("@") && password.Text.Length >= 3)
                {
                    if (password.Text == passwordconfirm.Text)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        bool MeetsCriteria2(User user)
        {
            try
            {
                var users = MySQLManager.LoadUsers();

                if(users.Where(x => x.email == user.email).Count() > 0)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}