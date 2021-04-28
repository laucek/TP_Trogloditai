using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace App1
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            //Map map = new Map();
            //Content = map;

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "placeholder text", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.StartAndExpand }

                }
            };
        }
    }
}
