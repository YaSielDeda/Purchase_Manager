using Purchase_Manager.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Manager.BL
{
    public class UserBL
    {
        private User _user;

        public UserBL(User user)
        {
            _user = user;
        }
        public UserBL() { }

        public User CreateUser(string name)
        {
            if (name.Length == 0)
                throw new FormatException("Enter the name");

            _user = new User(name);

            return _user;
        }
    }
}
