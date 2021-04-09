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
                    new Label { Text = "Loginas",
                        BackgroundColor = Color.Red
                    }
				}
			};
		}
	}
}