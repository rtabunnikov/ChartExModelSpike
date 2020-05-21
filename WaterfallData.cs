using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartExModelSpike {
    public class WaterfallData {
        public WaterfallData(string name, double amount) {
            Name = name;
            Amount = amount;
        }

        public string Name { get; private set; }
        public double Amount { get; private set; }

        public static List<WaterfallData> GetSampleData() {
            List<WaterfallData> data = new List<WaterfallData>();
            data.Add(new WaterfallData("Revenue", 23201));
            data.Add(new WaterfallData("Cost of goods", -8192));
            data.Add(new WaterfallData("Revenue 2", 16384));
            data.Add(new WaterfallData("Expense", -12345));
            data.Add(new WaterfallData("Revenue 3", 3201));
            return data;
        }
    }
}
