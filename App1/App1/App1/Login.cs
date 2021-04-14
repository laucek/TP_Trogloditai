using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App1
{
    public class Login : ContentPage
    {
        Entry userNameEntry;
        Entry passwordEntry;

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

            userNameEntry = new Entry
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
                    userNameEntry,
                    passwordEntry,

                    butt
                }
            };
        }

        private async void NavigateButton_OnClickedInLogin(object sender, EventArgs e, Button butt)
        {
            await Navigation.PushAsync(new HomePage());
        }
    }
}