using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App1
{
	public class Register : ContentPage
	{
		public Register ()
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "Welcome to Xamarin.Forms!" }
				}
			};
		}
	}
}