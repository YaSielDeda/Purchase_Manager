using Purchase_Manager.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Manager.BL
{
    public class UserBL
    {
        User user = null;
        public User CreateUser(string name)
        {
            if (name.Length == 0)
                throw new FormatException("Enter the name");

            user = new User(name);

            return user;
        }
    }
}
