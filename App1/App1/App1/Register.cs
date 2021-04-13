using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

using Xamarin.Forms;

namespace App1
{
    public class Register : ContentPage
    {
        Entry firstNameEntry;
        Entry username;
        Entry emailEntry;
        Entry password;
        Entry passwordconfirm;

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
                Placeholder = "Enter your first name",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            username = new Entry
            {
                Placeholder = "Enter your user name",
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
                Placeholder = "Enter your password",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            passwordconfirm = new Entry
            {
                Placeholder = "Confirm your passsword",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            butt.Clicked += async (sender, args) => OnButtonClicked(sender, args, butt);

            Content = new StackLayout
            {
                Children = {
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

                    butt

                    //new Button { Text = "Register", BackgroundColor = Color.White, BorderColor = Color.Black, BorderWidth = 3,
                    //HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand }

                    
                }

            };
        }

        void OnButtonClicked(object sender, EventArgs args, Button butt)
        {

            User user = new User(username.Text, emailEntry.Text, password.Text, firstNameEntry.Text, DateTime.Now);

            butt.Text = MySQLManager.InsertUser(user);

        }

        bool MeetsCriteria()
        {
            return true;
        }
    }
}