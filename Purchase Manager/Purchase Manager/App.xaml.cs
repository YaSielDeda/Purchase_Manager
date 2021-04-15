using Purchase_Manager.BL;
using Purchase_Manager.entities;
using Purchase_Manager.services;
using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace Purchase_Manager
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            /*Serializer serializer = new Serializer();
            serializer.SerializeDefault();

            Profile profile = serializer.Deserialize("Test_user.xml");*/

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new ListPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
