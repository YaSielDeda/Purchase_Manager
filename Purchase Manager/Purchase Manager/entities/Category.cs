using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Manager.entities
{
    public class Category
    {
        public string Name { get; set; }
        public List<string> Subcategories { get; set; }
        public Category() { }
        public Category(string name, List<string> subcategories)
        {
            Name = name;
            Subcategories = subcategories;
        }
    }
}
