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
    public partial class AddPurchase : ContentPage
    {
        Entry nameOfPruchase, description, amount;
        Picker categoryPicker;
        Profile profile;
        Serializer serializer;
        public AddPurchase()
        {
            InitializeComponent();

            serializer = new Serializer();
            serializer.SerializeDefault();

            profile = serializer.Deserialize("Test_user.xml");

            StackLayout stackLayout = new StackLayout();

            Label enter = new Label
            {
                Text = "History of purchases",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            nameOfPruchase = new Entry { Placeholder = "Name of purchase" };

            description = new Entry { Placeholder = "Description" };

            amount = new Entry { Placeholder = "Amount" };

            categoryPicker = new Picker { Title = "Category" };
            foreach (var category in profile.Categories)
            {
                categoryPicker.Items.Add(category.Name);
            }

            Button button = new Button
            {
                Text = "Add",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };

            button.Clicked += Add_Purchase_Button_Click;

            stackLayout.Children.Add(nameOfPruchase);
            stackLayout.Children.Add(categoryPicker);
            stackLayout.Children.Add(description);
            stackLayout.Children.Add(amount);
            stackLayout.Children.Add(button);
            Content = stackLayout;
        }

        private void Add_Purchase_Button_Click(object sender, EventArgs e)
        {
            Spend spend = new Spend 
            { 
                Name = nameOfPruchase.Text,
                Category = categoryPicker.Items[categoryPicker.SelectedIndex],
                Description = description.Text,
                Amount = double.Parse(amount.Text)
            };

            profile.Spends.Add(spend);

            serializer.Serialize(profile, "Test_user.xml");

            Navigation.PushAsync(new NavigationPage(new HistoryOfPurchases()));
        }
    }
}