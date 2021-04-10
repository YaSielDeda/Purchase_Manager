﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Manager.entities
{
    [Serializable]
    public class Profile
    {
        public User User { get; }
        public List<Category> Categories { get; set; }
        public List<Limit> Limits { get; set; }
        public List<Spend> Spends { get; set; }

        public Profile(User user, List<Category> categories, List<Limit> limits, List<Spend> spends)
        {
            User = user;
            Categories = categories;
            Limits = limits;
            Spends = spends;
        }
    }
}
