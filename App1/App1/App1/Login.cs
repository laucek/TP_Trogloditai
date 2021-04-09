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
			Content = new StackLayout {
				Children = {
					new Label { Text = "- Login into your account -", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.StartAndExpand },
					new Entry { Placeholder = "Enter your account name: ", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                    new Entry { Placeholder = "Enter your password: ", IsPassword = true, HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
					

					new Label { Text = "Loginas", BackgroundColor = Color.Red }

				}
			};
		}
	}
}