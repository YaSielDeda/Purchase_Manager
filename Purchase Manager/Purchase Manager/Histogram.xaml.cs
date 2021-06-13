﻿using Purchase_Manager.BL;
using Purchase_Manager.entities;
using Purchase_Manager.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.SfChart.XForms;

namespace Purchase_Manager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Histogram : ContentPage
    {
        public Histogram()
        {
            InitializeComponent();

            Serializer serializer = new Serializer();
            Profile profile = serializer.Deserialize("Test_user.xml");

            ExpenseStatisticsBL esBL = new ExpenseStatisticsBL(profile.Spends, profile.Categories);

            SfChart chart = new SfChart();

            HistogramSeries histogramSeries = new HistogramSeries()
            {
                ItemsSource = esBL.GetAllStatistics(),
                XBindingPath = "XValue",
                YBindingPath = "YValue",
                Interval = 20
            };
            chart.Series.Add(histogramSeries);
        }
    }
}