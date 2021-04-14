using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App1
{
    public class Login : ContentPage
    {
        Entry emailEntry;
        Entry passwordEntry;
        Label errorLabel;

        public Login ()
        {
            Button butt = new Button
            {
                Text = "Login",
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 3,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            errorLabel = new Label
            {
                IsVisible = false,
                Text = "Something went wrong, check your credentials",
                TextColor = Color.Red,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            emailEntry = new Entry
            {
                Placeholder = "Enter your first name",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            passwordEntry = new Entry
            {
                Placeholder = "Enter your password",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsPassword = true
            };

            butt.Clicked += async (sender, args) => NavigateButton_OnClickedInLogin(sender, args, butt);

            Content = new StackLayout {
                Children = {

                    new Label { Text = "Login into your account", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.StartAndExpand },
                    emailEntry,
                    passwordEntry,
                    butt,
                    errorLabel
                }
            };
        }

        private async void NavigateButton_OnClickedInLogin(object sender, EventArgs e, Button butt)
        {
            if (Crit())
            {
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                errorLabel.IsVisible = true;
            }
            
        }


        bool Crit()
        {
            List<User> users = MySQLManager.LoadUsers();

            try
            {
                if (users.Where(x => x.email == emailEntry.Text).Count() < 1)
                {
                    return false;
                }
                return users.Where(x => x.email == emailEntry.Text).FirstOrDefault().password == passwordEntry.Text;
            }
            catch
            {
                return false;
            }
           
        }
    }
}