using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChartsModel = DevExpress.Charts.Model;

namespace ChartExModelSpike {
    public static class Treemap {
        public static ChartsModel.TreeMap Create() {
            var chart = new ChartsModel.TreeMap();
            chart.GroupDataMember = "Meal";
            chart.LabelDataMember = "Product";
            chart.ValueDataMember = "Amount";
            var data = TreemapData.GetSampleData();
            chart.DataSource = data;
            chart.BorderColor = new ChartsModel.ColorARGB(255, 255, 255, 255);
            chart.ItemBorderVisible = true;
            chart.Palette = new ChartsModel.Palette(chart);
            foreach (var item in data) {
                byte r = (byte)((item.Color & 0x00ff0000) >> 16);
                byte g = (byte)((item.Color & 0x0000ff00) >> 8);
                byte b = (byte)(item.Color & 0x000000ff);
                chart.Palette.Entries.Add(new ChartsModel.PaletteEntry(new ChartsModel.ColorARGB(0xff, r, g, b)));
            }
            return chart;
        }
    }

    public class TreemapData {
        private const int Color1 = 0x4472c4;
        private const int Color2 = 0xed7d31;

        public TreemapData(string meal, string category, string product, double amount, int color) {
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
        public int Color { get; }

        public static List<TreemapData> GetSampleData() {
            var result = new List<TreemapData>();
            result.Add(new TreemapData("Breakfast", "Beverage", "Coffee", 20, Color1));
            result.Add(new TreemapData("Breakfast", "Beverage", "Tea", 9, Color1));
            result.Add(new TreemapData("Breakfast", "Food", "Waffles", 12, Color1));
            result.Add(new TreemapData("Breakfast", "Food", "Pancakes", 35, Color1));
            result.Add(new TreemapData("Breakfast", "Food", "Eggs", 24, Color1));
            result.Add(new TreemapData("Lunch", "Beverage", "Coffee", 10, Color2));
            result.Add(new TreemapData("Lunch", "Beverage", "Iced Tea", 45, Color2));
            result.Add(new TreemapData("Lunch", "Food", "Soup", 16, Color2));
            result.Add(new TreemapData("Lunch", "Food", "Sandwich", 36, Color2));
            result.Add(new TreemapData("Lunch", "Food", "Salad", 70, Color2));
            result.Add(new TreemapData("Lunch", "Food", "Pie", 45, Color2));
            result.Add(new TreemapData("Lunch", "Food", "Cookies", 25, Color2));
            //result.Sort((x, y) => x.Amount.CompareTo(y.Amount));
            return result;
        }
    }
}
