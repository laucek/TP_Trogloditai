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
                Text = "Enter your first name",
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

                    //Email
                    new Label { Text = "E-Mail address:*", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                    new Entry { Text = "Enter your e-mail here", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },


                    //Password
                    new Label { Text = "Password: *", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                    new Entry { Text = "Enter your password", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },

                    //Password confirmation
                    new Label { Text = "Password confirmation*", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                    new Entry { Text = "Confirm password", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },

                    butt

                    //new Button { Text = "Register", BackgroundColor = Color.White, BorderColor = Color.Black, BorderWidth = 3,
                    //HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand }

                    //new Label { Text = "First name*", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                    //new Entry { Text = "Enter your first name", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand }
                }

            };
        }

        void OnButtonClicked(object sender, EventArgs args, Button butt)
        {
            butt.Text = MySQLManager.InsertUser(new User(1, "A", "A", "A", "A", DateTime.Now));

        }
    }
}