using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Manager.entities
{
    public class Spend
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public DateTime SpendDate { get; }

        public Spend(string name, string category, double amount, string description, DateTime spendDate)
        {
            Name = name;
            Category = category;
            Amount = amount;
            Description = description;
            SpendDate = DateTime.Now;
        }
    }
}
