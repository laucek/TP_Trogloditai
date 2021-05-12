using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1
{
    class EditAccount : ContentPage
    {
        Entry emailEntry;
        Entry passwordEntry;
        Entry usernameEntry;
        Entry firstnameEntry;
        Entry repeatPasswordEntry;
        Label errorLabel;

        public EditAccount()
        {
            Button butt = new Button
            {
                Text = "Change settings",
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 3,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };


            emailEntry = new Entry
            {
                Text = Session.Email,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };


            passwordEntry = new Entry
            {
                Text = Session.Password,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsPassword = true
            };
            repeatPasswordEntry = new Entry
            {
                Text = Session.Password,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsPassword = true
            };

            usernameEntry = new Entry
            {
                Text = Session.Username,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            firstnameEntry = new Entry
            {
                Text = Session.Firstname,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            errorLabel = new Label
            {
                IsVisible = false,
                Text = "Something went wrong, check your credentials: \nAny field can not be empty\nName and Username should be at least 4 digits long\nPassword must be at least 6 symbols long\n",
                TextColor = Color.Red,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            butt.Clicked += async (sender, args) => NavigateButton_OnClickedInLogin(sender, args, butt);

            ScrollView scrollView = new ScrollView
            {
                Content = new StackLayout
                {
                    Children = {

                    new Label { Text = "Change account info", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.StartAndExpand },
                        //First name
					    new Label { Text = "First name:*", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        firstnameEntry,

                        //User name
                        new Label { Text = "User name*", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        usernameEntry,

                        //Email
                        new Label { Text = "E-Mail address:*", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        emailEntry,


                        //Password
                        new Label { Text = "Password: *", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        passwordEntry,

                        //Password confirmation
                        new Label { Text = "Password confirmation*", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        repeatPasswordEntry,

                        butt,
                        errorLabel
                    }
                }
            };
            Content = scrollView;
            
        }


        private void NavigateButton_OnClickedInLogin(object sender, EventArgs e, Button butt)
        {
            if (Crit())
            {
                User user = new User(Session.Id, usernameEntry.Text, emailEntry.Text, passwordEntry.Text, firstnameEntry.Text, Session.Registrationdate);
                MySQLManager.UpdateUserInfo(user);
                butt.Text = passwordEntry.Text;
            }
            else
            {
                errorLabel.IsVisible = true;
            }

        }
        bool Crit()
        {
            try
            {
                if (firstnameEntry.Text.Length >= 3 && usernameEntry.Text.Length >= 3 && passwordEntry.Text.Length >= 6 && emailEntry.Text.Contains("@") && emailEntry.Text.Contains("."))
                {
                    if (passwordEntry.Text == repeatPasswordEntry.Text)
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


        }
}
