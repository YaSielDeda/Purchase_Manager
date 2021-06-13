using Purchase_Manager.entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Purchase_Manager.BL
{
    class ExpenseStatisticsBL
    {
        private List<Spend> _spends;
        private List<Category> _categories;    
        public ExpenseStatisticsBL(List<Spend> spends, List<Category> categories)
        {
            _spends = spends;
            _categories = categories;
        }
        public ObservableCollection<HistogramModel> TestData()
        {
            ObservableCollection<HistogramModel> observableCollection = new ObservableCollection<HistogramModel>();
            observableCollection.Add(new HistogramModel("Jan", 50));
            observableCollection.Add(new HistogramModel("Feb", 70));
            observableCollection.Add(new HistogramModel("Mar", 65));
            observableCollection.Add(new HistogramModel("Apr", 57));
            observableCollection.Add(new HistogramModel("May", 48));

            return observableCollection;
        }
        public Dictionary<string, double> GetAllStatistics()
        {
            Dictionary<string, double> statistics = new Dictionary<string, double>();
            foreach (var category in _categories)
            {
                statistics.Add(category.Name, 0.0);
            }

            DateTime nowDate = DateTime.Now;
            foreach (var spend in _spends)
            {
                statistics[spend.Category] += spend.Amount;
            }

            return statistics;
        }
        public Dictionary<string, double> GetYearStatistics()
        {
            Dictionary<string, double> statistics = new Dictionary<string, double>();
            foreach (var category in _categories)
            {
                statistics.Add(category.Name, 0.0);
            }

            DateTime nowDate = DateTime.Now;
            foreach (var spend in _spends)
            {
                if(spend.SpendDate.Year == nowDate.Year)
                {
                    statistics[spend.Category] += spend.Amount;
                }
            }
            return statistics;
        }
        public Dictionary<string, double> GetSixMonthsStatistics()
        {
            Dictionary<string, double> statistics = new Dictionary<string, double>();
            foreach (var category in _categories)
            {
                statistics.Add(category.Name, 0.0);
            }

            DateTime nowDate = DateTime.Now;
            DateTime SixMonthsAgo = nowDate.AddMonths(-6);
            foreach (var spend in _spends)
            {
                if (spend.SpendDate <= nowDate || SixMonthsAgo <= spend.SpendDate)
                {
                    statistics[spend.Category] += spend.Amount;
                }
            }
            return statistics;
        }
       
        public Dictionary<string, double> GetMonthlyStatistics()
        {
            Dictionary<string, double> statistics = new Dictionary<string, double>();
            foreach (var category in _categories)
            {
                statistics.Add(category.Name, 0.0);
            }

            DateTime nowDate = DateTime.Now;
            DateTime monthAgo = nowDate.AddMonths(-1);
            foreach (var spend in _spends)
            {
                if (spend.SpendDate <= nowDate || monthAgo <= spend.SpendDate)
                {
                    statistics[spend.Category] += spend.Amount;
                }
            }
            return statistics;
        }
        public Dictionary<string, double> GetDayStatistics()
        {
            Dictionary<string, double> statistics = new Dictionary<string, double>();
            foreach (var category in _categories)
            {
                statistics.Add(category.Name, 0.0);
            }

            DateTime nowDate = DateTime.Now;
            DateTime OneDayAgo = nowDate.AddDays(-1);
            foreach (var spend in _spends)
            {
                if (spend.SpendDate <= nowDate || OneDayAgo <= spend.SpendDate)
                {
                    statistics[spend.Category] += spend.Amount;
                }
            }
            return statistics;
        }
        public void Refresh()
        {

        }
    }
}
