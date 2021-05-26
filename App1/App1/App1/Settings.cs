using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1
{
    class Settings : ContentPage
    {
        public Settings()
        {
            Picker picker = new Picker()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Button button = new Button()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = Session.Language.ConfirmString
            };

            picker.Items.Add("English");
            picker.Items.Add("Lietuvių");

            picker.SelectedIndex = 0;

            button.Clicked += async (sender, args) => await buttonClick(sender, args, picker);

            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label { Text = Session.Language.SettingsString, HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                        picker,
                        button
                    }
                }
            };

            Content = scrollView;
        }
        async System.Threading.Tasks.Task buttonClick(object sender, EventArgs args, Picker picker)
        {
            if(picker.SelectedIndex == 0)
            {
                Session.Language = new Assets.English();
            }
            else
            {
                Session.Language = new Assets.Lithuanian();
            }
            await Navigation.PushAsync(new HomePage());
        }

    }
}
