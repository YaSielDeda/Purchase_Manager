using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Manager.entities
{
    public class User
    {
        public string Name { get; set; }
        private DateTime RegistrationDate { get; }

        public User(string name)
        {
            Name = name;
            RegistrationDate = DateTime.Now;
        }
    }
}
