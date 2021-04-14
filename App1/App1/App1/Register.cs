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

        public Register()
        {
            

            Button butt = new Button
            {
                Text = "Register",
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 3,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            firstNameEntry = new Entry
            {
                Placeholder = "Atleast 3 characters",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            username = new Entry
            {
                Placeholder = "Atleast 3 characters",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            emailEntry = new Entry
            {
                Placeholder = "Enter your email address",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            password = new Entry
            {
                Placeholder = "Atleast 3 characters",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            passwordconfirm = new Entry
            {
                Placeholder = "Atleast 3 characters",
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

            butt.Clicked += async (sender, args) => await OnButtonClicked(sender, args, butt);

            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = new StackLayout
                {
                    Children =
                    {
                        //First name
					    new Label { Text = "First name:*", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        firstNameEntry,

                        //User name
                        new Label { Text = "User name*", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        username,

                        //Email
                        new Label { Text = "E-Mail address:*", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        emailEntry,


                        //Password
                        new Label { Text = "Password: *", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        password,

                        //Password confirmation
                        new Label { Text = "Password confirmation*", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        passwordconfirm,

                        butt,
                        errorLabel
                        
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

                butt.Text = MySQLManager.InsertUser(user);

                await Navigation.PushAsync(new Login());
            }

        }

        bool MeetsCriteria()
        {
            if(firstNameEntry.Text.Length >= 3 && username.Text.Length >= 3 && emailEntry.Text.Length >= 6 && emailEntry.Text.Contains("@") && password.Text.Length >= 3)
            {
                if(password.Text == passwordconfirm.Text)
                {
                    return true;
                }
            }
            return false;
        }
    }
}