using Purchase_Manager.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Manager.BL
{
    class SpendBL
    {
        private Spend _spend;

        public SpendBL(Spend spend)
        {
            _spend = spend;
        }
        public SpendBL() { }

        public Spend CreateSpend(string name, string category, double amount, string description)
        {
            if (name.Length == 0)
                throw new FormatException("Enter the name");
            if (category.Length == 0)
                throw new FormatException("Enter the category");
            if (amount == 0)
                throw new FormatException("Enter the amount");

            _spend = new Spend(name, category, amount, description);

            return _spend;
        }
    }
}
