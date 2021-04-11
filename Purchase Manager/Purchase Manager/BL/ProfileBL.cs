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
    }
}
