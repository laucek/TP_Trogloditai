using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
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
                Text = Session.Language.LoginString,
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
                Placeholder = Session.Language.EnterEmailString,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            passwordEntry = new Entry
            {
                Placeholder = Session.Language.PasswordString,
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
                List<User> users = MySQLManager.LoadUsers();
                User usr = users.Where(x => x.email == emailEntry.Text).FirstOrDefault();

                setUserSession(usr);
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
                User usr = users.Where(x => x.email == emailEntry.Text).FirstOrDefault();
                return usr.password == passwordEntry.Text;
            }
            catch
            {
                return false;
            }
           
        }

        void setUserSession(User user)
        {
            Session.Id = user.id;
            Session.Email = user.email;
            Session.Password = user.password;
            Session.Firstname = user.first_name;
            Session.Username = user.username;
            Session.Registrationdate = user.registration_date;
        }
    }
}