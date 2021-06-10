using Purchase_Manager.BL;
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
    public partial class EditPurchase : ContentPage
    {
        Entry nameOfPruchase, description, amount;
        Picker categoryPicker;
        Profile profile;
        Serializer serializer;
        Spend SpendBefore;
        int indexOfElement;
        public EditPurchase(Spend spend, int index)
        {
            InitializeComponent();

            serializer = new Serializer();

            profile = serializer.Deserialize("Test_user.xml");

            StackLayout stackLayout = new StackLayout();

            Label enter = new Label
            {
                Text = "History of purchases",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            nameOfPruchase = new Entry { Placeholder = "Name of purchase", Text = spend.Name};

            description = new Entry { Placeholder = "Description", Text = spend.Description };

            amount = new Entry { Placeholder = "Amount", Text = spend.Amount.ToString() };

            categoryPicker = new Picker { Title = "Category"};
            foreach (var category in profile.Categories)
            {
                categoryPicker.Items.Add(category.Name);
            }

            Button EditButton = new Button
            {
                Text = "Edit",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };
            Button DeleteButton = new Button
            {
                Text = "Delete",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };

            SpendBefore = spend;
            indexOfElement = index;

            EditButton.Clicked += Edit_Purchase_Button_Click;
            DeleteButton.Clicked += Delete_Purchase_Button_Click;

            stackLayout.Children.Add(nameOfPruchase);
            stackLayout.Children.Add(categoryPicker);
            stackLayout.Children.Add(description);
            stackLayout.Children.Add(amount);
            stackLayout.Children.Add(EditButton);
            stackLayout.Children.Add(DeleteButton);
            Content = stackLayout;
        }
        private void Delete_Purchase_Button_Click(object sender, EventArgs e)
        {
            profile = serializer.Deserialize("Test_user.xml");
            ProfileBL profileBL = new ProfileBL(profile);
            profileBL.DeleteSpendByIndex(indexOfElement);
            serializer.Serialize(profile, "Test_user.xml");

            Navigation.PushAsync(new HistoryOfPurchases());
        }
        private void Edit_Purchase_Button_Click(object sender, EventArgs e)
        {
            Serializer serializer = new Serializer();

            Spend spend = new Spend
            {
                Name = nameOfPruchase.Text,
                Category = categoryPicker.Items[categoryPicker.SelectedIndex],
                Description = description.Text,
                Amount = double.Parse(amount.Text),
                SpendDate = SpendBefore.SpendDate
            };

            profile = serializer.Deserialize("Test_user.xml");
            ProfileBL profileBL = new ProfileBL(profile);
            profileBL.ChangeSpend(spend);

            serializer.Serialize(profile, "Test_user.xml");

            Navigation.PushAsync(new HistoryOfPurchases());
        }
    }
}