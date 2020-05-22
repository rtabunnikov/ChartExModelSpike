using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartExModelSpike {
    public class BoxWhiskerData {
        public BoxWhiskerData(string name, double min, double quartile1, double median, double quartile3, double max, double mean) {
            Name = name;
            Min = min;
            Quartile1 = quartile1;
            Median = median;
            Quartile3 = quartile3;
            Max = max;
            Mean = mean;
            Outliers = new double[0];
        }

        public string Name { get; set; }
        public double Min { get; set; }
        public double Quartile1 { get; set; }
        public double Median { get; set; }
        public double Quartile3 { get; set; }
        public double Max { get; set; }
        public double Mean { get; set; }
        public double[] Outliers { get; set; }

        public static List<BoxWhiskerData> GetSampleData(int seriesIndex) {
            var data = new List<BoxWhiskerData>();
            if (seriesIndex == 0) {
                data.Add(new BoxWhiskerData("English", 58, 58.25, 61.5, 63, 63, 59.375) { Outliers = new double[] { 46 } });
                data.Add(new BoxWhiskerData("Physics", 60, 60, 60.5, 61, 61, 60.5));
                data.Add(new BoxWhiskerData("Math", 60, 60.5, 62, 62.5, 63, 61.5));
            }
            else if (seriesIndex == 1) {
                data.Add(new BoxWhiskerData("English", 50, 52.25, 53.5, 55.5, 56, 53.5));
                data.Add(new BoxWhiskerData("Physics", 55, 55, 55.5, 56, 56, 55.5));
                data.Add(new BoxWhiskerData("Math", 51, 51, 53, 57, 58, 53.8));
            }
            else {
                data.Add(new BoxWhiskerData("English", 63.25, 64, 64.25, 65.5, 67, 63.25) { Outliers = new double[] { 45, 69 } });
                data.Add(new BoxWhiskerData("Physics", 64, 64, 64.5, 65, 65, 64.5));
                data.Add(new BoxWhiskerData("Math", 45, 54.5, 64, 66.5, 67, 61.2));
            }
            return data;
        }
    }
}
