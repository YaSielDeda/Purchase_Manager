using Purchase_Manager.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Manager.BL
{
    public class CategoryBL
    {
        private List<Category> _categories;

        public CategoryBL(List<Category> categories)
        {
            _categories = categories;
        }
        public CategoryBL()
        {
            _categories = new List<Category>();
        }

        public List<Category> CreateDefaultList()
        {
            _categories = new List<Category>() 
            {
                new Category("Rent", new List<string>() { "Property", "Transport" }),
                new Category("Traveling", new List<string>()),
                new Category("Repair", new List<string>() { "Phone", "Property" }),
                new Category("Education", new List<string>() { "University", "Courses" }),
                new Category("Household", new List<string>() { "Furniture", "Tech" }),
                new Category("Sport", new List<string>() { "Nutrition", "Gym" }),
                new Category("Communication", new List<string>() { "Internet", "TV" }),
                new Category("Utilities", new List<string>() { "Electricity", "Water" }),
                new Category("Transport", new List<string>() { "Vehicle", "Public transport" }),
                new Category("Food", new List<string>() { "Drinks", "Fast food", "Alcohol" }),
                new Category("Health and beauty", new List<string>() { "Meds", "Cosmetics" }),
                new Category("Clothes and accessories", new List<string>() { "Boots", "Pants", "Watches" }),
                new Category("Investitions and deposits", new List<string>() { "Credits", "Stocks", "Bonds" }),
                new Category("Children's products", new List<string>() { "Food", "Toys" }),
                new Category("Books", new List<string>() {}),
                new Category("Restaraunt/bar", new List<string>() { "Restaraunt", "Club", "Bar" }),
                new Category("Sport", new List<string>() { "Nutrition", "Gym" }),
                new Category("Other", new List<string>() { }),
            };

            return _categories;
        }
        public Category CreateCategory(string name ,List<string> subcategories)
        {
            Category category = null;

            if (name.Length == 0)
                throw new FormatException("Enter name of category");

            category = new Category(name, subcategories);

            return category;
        }

        public void AddCategory(Category category)
        {
            _categories.Add(category);
        }
        public void DeleteCategory(Category category)
        {
            _categories.Remove(category);
        }
    }
}
