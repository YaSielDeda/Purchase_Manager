using Purchase_Manager.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Manager.BL
{
    public class ProfileBL
    {
        private Profile _profile;
        private UserBL _userBL;
        private CategoryBL _categoryBL;
        private SpendBL _spendBL;

        public ProfileBL(Profile profile)
        {
            _profile = profile;
            _userBL = new UserBL();
            _categoryBL = new CategoryBL();
        }

        public void CreateDefaultProfile(string name)
        {
            _profile.User = _userBL.CreateUser(name);
            _profile.Categories = _categoryBL.CreateDefaultList();
        }

        public void AddSpend(string name, string category, double amount, string description)
        {
            _spendBL.CreateSpend(name, category, amount, description);
        }
    }
}
