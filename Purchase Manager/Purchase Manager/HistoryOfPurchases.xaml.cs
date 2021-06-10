using Purchase_Manager.entities;
using Purchase_Manager.services;
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
    public partial class HistoryOfPurchases : ContentPage
    {
        Profile profile;
        Spend spend;
        List<string> names;
        ListView purchases;
        public HistoryOfPurchases()
        {
            InitializeComponent();

            StackLayout stackLayout = new StackLayout();

            Serializer serializer = new Serializer();
            profile = serializer.Deserialize("Test_user.xml");

            Label header = new Label
            {
                Text = "History of purchases",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            purchases = new ListView();
            names = new List<string>();
            foreach (var item in profile.Spends)
            {
                names.Add(item.Name + "\t" + item.SpendDate + Environment.NewLine + item.Category);
            }
            purchases.ItemsSource = names;
            Content = new StackLayout { Children = { header, purchases } };

            Button button = new Button
            {
                Text = "Add new spend",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };

            purchases.ItemSelected += ClickOnElement;
            button.Clicked += OnButtonClicked;

            stackLayout.Children.Add(purchases);
            stackLayout.Children.Add(button);
            Content = stackLayout;
        }
        private void ClickOnElement(object sender, System.EventArgs e)
        {
            int index = names.IndexOf(purchases.SelectedItem.ToString());
            spend = profile.Spends[names.IndexOf(purchases.SelectedItem.ToString())];
            Navigation.PushAsync(new EditPurchase(spend, index));
        }
        private void OnButtonClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddPurchase());
        }
    }
}