using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Purchase_Manager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();

            StackLayout stackLayout = new StackLayout();

            Button toHistory = new Button
            {
                Text = "History of purchases",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };
            Button toHistogram = new Button
            {
                Text = "Histogram",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };

            toHistory.Clicked += OnHistoryClicked;
            toHistogram.Clicked += OnHistogramClicked;

            stackLayout.Children.Add(toHistory);
            stackLayout.Children.Add(toHistogram);
            Content = stackLayout;
        }
        private void OnHistoryClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new HistoryOfPurchases());
        }
        private void OnHistogramClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Histogram());
        }
    }
}