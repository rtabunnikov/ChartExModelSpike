using System;
using System.Collections.Generic;
using ChartsModel = DevExpress.Charts.Model;

namespace ChartExModelSpike {
    public static class Sunburst {
        public static ChartsModel.Sunburst Create() {
            var chart = new ChartsModel.Sunburst();
            chart.GroupDataMember = "Meal";
            chart.LabelDataMember = "Product";
            chart.ValueDataMember = "Amount";
            chart.ColorDataMember = "Color";
            var data = SunburstData.GetSampleData();
            chart.DataSource = data;
            
            chart.Palette = new ChartsModel.Palette(chart);
            chart.Palette.Entries.Add(new ChartsModel.PaletteEntry(new ChartsModel.ColorARGB(0xff, 0x44, 0x72, 0xc4)));
            chart.Palette.Entries.Add(new ChartsModel.PaletteEntry(new ChartsModel.ColorARGB(0xff, 0xed, 0x7d, 0x31)));
            chart.Palette.Entries.Add(new ChartsModel.PaletteEntry(new ChartsModel.ColorARGB(0xff, 0xa5, 0xa5, 0xa5)));
            return chart;
        }
    }
    public class SunburstData {
        public SunburstData(string meal, string category, string product, double amount, int? color = null) {
            Meal = meal;
            Category = category;
            Product = product;
            Amount = amount;
            Color = color;
        }

        public string Meal { get; }
        public string Category { get; }
        public string Product { get; }
        public double Amount { get; }
        public int? Color { get; }

        public static List<TreemapData> GetSampleData() {
            var result = new List<TreemapData>();
            result.Add(new TreemapData("Breakfast", "Beverage", "Coffee", 20));
            result.Add(new TreemapData("Breakfast", "Beverage", "Tea", 9));
            result.Add(new TreemapData("Breakfast", "Food", "Waffles", 12));
            result.Add(new TreemapData("Breakfast", "Food", "Pancakes", 35));
            result.Add(new TreemapData("Breakfast", "Food", "Eggs", 24));
            result.Add(new TreemapData("Lunch", "Beverage", "Coffee", 10));
            result.Add(new TreemapData("Lunch", "Beverage", "Iced Tea", 45, unchecked((int)0xff33aa33)));
            result.Add(new TreemapData("Lunch", "Food", "Soup", 16));
            result.Add(new TreemapData("Lunch", "Food", "Sandwich", 36));
            result.Add(new TreemapData("Lunch", "Food", "Salad", 70));
            result.Add(new TreemapData("Lunch", "Food", "Pie", 45));
            result.Add(new TreemapData("Lunch", "Food", "Cookies", 25, unchecked((int)0xff6666aa)));
            //result.Add(new TreemapData("Supper", "Beverage", "Vine", 75));
            //result.Add(new TreemapData("Supper", "Food", "Fish", 125));
            //result.Add(new TreemapData("Supper", "Food", "Meat", 150));
            return result;
        }
    }
}
