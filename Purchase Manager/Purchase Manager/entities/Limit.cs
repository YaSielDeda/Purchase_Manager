using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Manager.entities
{
    public class Limit
    {
        public string ID { get; }
        public string Category { get; set; }
        public string Period { get; set; }
        public double LimitValue { get; set; }
        public double AllertValue { get; set; }

        public Limit(string category, string period, double limitValue, double allertValue)
        {
            ID = Guid.NewGuid().ToString();
            Category = category;
            Period = period;
            LimitValue = limitValue;
            AllertValue = allertValue;
        }
    }
}
