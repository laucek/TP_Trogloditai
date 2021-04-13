using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App1
{
	public class Login : ContentPage
	{
		public Login ()
		{
            Button butt = new Button
            {
                Text = "Login",
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 3,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            butt.Clicked += async (sender, args) => NavigateButton_OnClickedInLogin(sender, args, butt);

            Content = new StackLayout {
                Children = {
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