using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Manager.entities
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }
        private DateTime RegistrationDate { get; }
        private User() { }

        public User(string name)
        {
            Name = name;
            RegistrationDate = DateTime.Now;
        }
    }
}
