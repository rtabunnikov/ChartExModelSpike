using DevExpress.Charts.Model;
using System;
using System.Collections.Generic;
using ChartsModel = DevExpress.Charts.Model;

namespace ChartExModelSpike {
    public static class Sunburst {
        public static ChartsModel.Sunburst Create() {
            var chart = new ChartsModel.Sunburst();
            chart.GroupDataMembers = new string[] { "Quarter", "Month" };
            chart.LabelDataMember = "Week";
            chart.ValueDataMember = "Sales";
            chart.ColorDataMember = "Color";
            var data = SunburstData.GetSampleData();
            chart.DataSource = data;

            chart.LabelFormatter = new SunburstDataLabelFormatter();
            
            chart.Palette = new ChartsModel.Palette(chart);
            chart.Palette.Entries.Add(new ChartsModel.PaletteEntry(new ChartsModel.ColorARGB(0xff, 0x44, 0x72, 0xc4)));
            chart.Palette.Entries.Add(new ChartsModel.PaletteEntry(new ChartsModel.ColorARGB(0xff, 0xed, 0x7d, 0x31)));
            chart.Palette.Entries.Add(new ChartsModel.PaletteEntry(new ChartsModel.ColorARGB(0xff, 0xa5, 0xa5, 0xa5)));
            return chart;
        }
    }
    public class SunburstData {
        public SunburstData(string quarter, string month, string week, double sales, int? color = null) {
            Quarter = quarter;
            Month = month;
            Week = week;
            Sales = sales;
            Color = color;
        }

        public string Quarter { get; }
        public string Month { get; }
        public string Week { get; }
        public double Sales { get; }
        public int? Color { get; }

        public static List<SunburstData> GetSampleData() {
            var result = new List<SunburstData>();
            result.Add(new SunburstData("1st", "Jan", "", 3.5));
            result.Add(new SunburstData("", "Feb", "Week1", 1.2));
            result.Add(new SunburstData("", "", "Week2", 0.8));
            result.Add(new SunburstData("", "", "Week3", 0.6));
            result.Add(new SunburstData("", "", "Week4", 0.5));
            result.Add(new SunburstData("", "Mar", "", 1.7));
            result.Add(new SunburstData("2nd", "Apr", "", 1.1, unchecked((int)0xff33aa33)));
            result.Add(new SunburstData("", "May", "", 0.8));
            result.Add(new SunburstData("", "Jun", "", 0.3));
            result.Add(new SunburstData("3rd", "Jul", "", 0.7));
            result.Add(new SunburstData("", "Aug", "", 0.6));
            result.Add(new SunburstData("", "Sep", "", 0.1, unchecked((int)0xff6666aa)));
            result.Add(new SunburstData("4th", "Oct", "", 0.5));
            result.Add(new SunburstData("", "Nov", "", 0.4, 0));
            result.Add(new SunburstData("", "Dec", "", 0.3));
            return result;
        }
    }
    public class SunburstDataLabelFormatter : IDataLabelFormatter {
        public string GetDataLabelText(LabelPointData pointData) {
            return (string)pointData.Argument;
        }
    }
}
