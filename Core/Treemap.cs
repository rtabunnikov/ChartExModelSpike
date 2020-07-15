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
            chart.DataSource = TreemapData.GetSampleData();
            return chart;
        }
    }

    public class TreemapData {

        public TreemapData(string meal, string category, string product, double amount) {
            Meal = meal;
            Category = category;
            Product = product;
            Amount = amount;
        }

        public string Meal { get; }
        public string Category { get; }
        public string Product { get; }
        public double Amount { get; }

        public static List<TreemapData> GetSampleData() {
            var result = new List<TreemapData>();
            result.Add(new TreemapData("Breakfast", "Beverage", "Coffee", 20));
            result.Add(new TreemapData("Breakfast", "Beverage", "Tea", 9));
            result.Add(new TreemapData("Breakfast", "Food", "Waffles", 12));
            result.Add(new TreemapData("Breakfast", "Food", "Pancakes", 35));
            result.Add(new TreemapData("Breakfast", "Food", "Eggs", 24));
            result.Add(new TreemapData("Lunch", "Beverage", "Coffee", 10));
            result.Add(new TreemapData("Lunch", "Beverage", "Iced Tea", 45));
            result.Add(new TreemapData("Lunch", "Food", "Soup", 16));
            result.Add(new TreemapData("Lunch", "Food", "Sandwich", 36));
            result.Add(new TreemapData("Lunch", "Food", "Salad", 70));
            result.Add(new TreemapData("Lunch", "Food", "Pie", 45));
            result.Add(new TreemapData("Lunch", "Food", "Cookies", 25));
            return result;
        }
    }
}
