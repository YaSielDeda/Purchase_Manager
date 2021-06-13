using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase_Manager.entities
{
    class HistogramModel
    {
        public string XValue { get; set; }

        public double YValue { get; set; }

        public HistogramModel(string xValue, double yValue)
        {
            XValue = xValue;
            YValue = yValue;
        }
    }
}
