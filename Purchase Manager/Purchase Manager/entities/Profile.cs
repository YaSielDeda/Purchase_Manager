using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Purchase_Manager.entities
{
    [Serializable]
    public class Profile : INotifyPropertyChanged
    {
        private User _user;
        private List<Category> _categories;
        private List<Limit> _limits;
        private List<Spend> _spends;
        public User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                OnPropertyChanged("User");
            }
        }
        /*public List<Spend> Spend
        {
            get
            {
                return _spends;
            }
            set
            {
                _spends = value;
                OnPropertyChanged("Spend");
            }
        }*/
        public List<Category> Categories { get; set; }
        public List<Limit> Limits { get; set; }
        public List<Spend> Spends { get; set; }
        public Profile() { }
        public Profile(User user, List<Category> categories, List<Limit> limits, List<Spend> spends)
        {
            User = user;
            Categories = categories;
            Limits = limits;
            Spends = spends;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(prop));
        }
    }
}
