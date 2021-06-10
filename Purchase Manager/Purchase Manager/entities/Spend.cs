using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace Purchase_Manager.entities
{
    [Serializable]
    public class Spend
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public DateTime SpendDate { get; set; }
        public Spend() { }

        public Spend(string name, string category, double amount, string description)
        {
            Name = name;
            Category = category;
            Amount = amount;
            Description = description;
            SpendDate = DateTime.Now;
        }
    }
}
