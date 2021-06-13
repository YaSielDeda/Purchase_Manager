using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Purchase_Manager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HstFlyout : ContentPage
    {
        public ListView ListView;

        public HstFlyout()
        {
            InitializeComponent();

            BindingContext = new HstFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class HstFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<HstFlyoutMenuItem> MenuItems { get; set; }

            public HstFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<HstFlyoutMenuItem>(new[]
                {
                    new HstFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new HstFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new HstFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new HstFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new HstFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}