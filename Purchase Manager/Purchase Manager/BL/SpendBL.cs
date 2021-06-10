using Purchase_Manager.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Purchase_Manager.BL
{
    public class SpendBL
    {
        private List<Spend> _spends;

        public SpendBL(List<Spend> spends)
        {
            _spends = spends;
        }
        public SpendBL() { }

        public List<Spend> CreateDefaultSpendsList()
        {
            _spends = new List<Spend>()
            {
                new Spend("Abonement", "Sport", 2000, "gym abonement for 1 month"),
                new Spend("Pack of juice", "Food", 50, ""),
                new Spend("Bus ticket", "Transport", 23, "")
            };
            return _spends;
        }

        public void CreateSpend(string name, string category, double amount, string description)
        {
            if (name.Length == 0)
                throw new FormatException("Enter the name");
            if (category.Length == 0)
                throw new FormatException("Enter the category");
            if (amount == 0)
                throw new FormatException("Enter the amount");

            _spends.Add(new Spend(name, category, amount, description));
        }
        public void DeleteSpend(int index)
        {
            _spends.RemoveAt(index);
        }
        public void ChangeSpend(Spend spend)
        {
            int index = _spends.IndexOf(_spends.Where(n => n.SpendDate == spend.SpendDate).FirstOrDefault());
            _spends[index] = spend;
        }
    }
}
