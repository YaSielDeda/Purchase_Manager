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
    public partial class AddCategory : ContentPage
    {
        Category category;
        Profile profile;
        public AddCategory()
        {
            InitializeComponent();
        }

        private void nameCategory_TextChanged(object sender, EventArgs args)
        {
            category = new Category() {
                Name = args.ToString()
            };
        }

        private void Add_Category_Button_Click(object sender, EventArgs args)
        {
            Serializer serializer = new Serializer();
            //serializer.SerializeDefault();

            profile = serializer.Deserialize("Test_user.xml");
            profile.Categories.Add(category);
            serializer.Serialize(profile, "Test_user.xml");
        }
    }
}