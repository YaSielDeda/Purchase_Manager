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
            _userBL = new UserBL(profile.User);
            _categoryBL = new CategoryBL(profile.Categories);
            _spendBL = new SpendBL(profile.Spends);
        }

        public void CreateDefaultProfile(string name)
        {
            _profile.User = _userBL.CreateUser(name);
            _profile.Categories = _categoryBL.CreateDefaultList();
            _profile.Spends = _spendBL.CreateDefaultSpendsList();
        }

        public void AddSpend(Spend spend)
        {
            _spendBL.CreateSpend(spend.Name, spend.Category, spend.Amount, spend.Description);
        }
        public void DeleteSpendByIndex(int index)
        {
            _spendBL.DeleteSpend(index);
        }
        public void ChangeSpend(Spend spend)
        {
            _spendBL.ChangeSpend(spend);
        }
    }
}
