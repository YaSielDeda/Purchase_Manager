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
    public partial class ListPage : ContentPage
    {
        Profile profile;
        public ListPage()
        {
            InitializeComponent();

            Serializer serializer = new Serializer();
            serializer.SerializeDefault();

            profile = serializer.Deserialize("Test_user.xml");

            BindingContext = profile;
        }

        private void categoriesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void Add_Category_Button_Click(object sender, EventArgs args)
        {
            profile.Categories.Add(new Category() {Name="New Category", Subcategories=new List<string> { } });
        }
    }
}