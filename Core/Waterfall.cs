using System.Collections.Generic;
using ChartsModel = DevExpress.Charts.Model;
using DevExpress.Utils;
using DevExpress.Charts.Model;

namespace ChartExModelSpike {
    public static class Waterfall {
        public static ChartsModel.Chart Create() {
            var chart = new ChartsModel.CartesianChart();

            // Argument Axis
            chart.ArgumentAxis = new ChartsModel.Axis() {
                Position = ChartsModel.AxisPosition.Bottom,
                GridLinesVisible = false,
                GridLinesMinorVisible = false,
                TickmarksVisible = false,
                Visible = true
            };

            chart.ArgumentAxis.Label = new ChartsModel.AxisLabel(chart.ArgumentAxis) {
                EnableAntialiasing = DefaultBoolean.True,
                Visible = true
            };

            // Value Axis
            chart.ValueAxis = new ChartsModel.Axis() {
                Position = ChartsModel.AxisPosition.Left,
                GridLinesVisible = true,
                GridLinesMinorVisible = false,
                TickmarksVisible = true,
                Visible = true
            };

            chart.ValueAxis.Label = new ChartsModel.AxisLabel(chart.ValueAxis) {
                EnableAntialiasing = DefaultBoolean.True,
                Visible = true
            };

            // Series
            var series = new ChartsModel.WaterfallSeries {
                DisplayName = "Series1",
                LabelsVisibility = true
            };

            var sampleData = WaterfallData.GetSampleData();
            series.DataMembers[ChartsModel.DataMemberType.Argument] = "Name";
            series.DataMembers[ChartsModel.DataMemberType.Value] = "Amount";
            series.DataMembers[ChartsModel.DataMemberType.Color] = "PointColor";
            series.DataSource = sampleData;

            series.Label = new ChartsModel.SeriesLabel(series) {
                EnableAntialiasing = DefaultBoolean.True,
                Position = ChartsModel.SeriesLabelPosition.Top
            };
            series.Appearance = new ChartsModel.SeriesAppearance() {
                Color = new ChartsModel.ColorARGB(0xff, 0x44, 0x72, 0xc4),
                LabelAppearance = new ChartsModel.SeriesLabelAppearance() {
                    LineVisible = false,
                    Border = new ChartsModel.Border() { Color = ChartsModel.ColorARGB.Transparent },
                    TextColor = new ChartsModel.ColorARGB(255, 0, 0, 0),
                    BackColor = ChartsModel.ColorARGB.Transparent
                },
            };

            //series.RisingBarColor = new ChartsModel.ColorARGB(0xff, 0x44, 0x72, 0xc4);
            series.FallingBarColor = new ChartsModel.ColorARGB(0xff, 0xed, 0x7d, 0x31);
            series.SubtotalBarColor = new ChartsModel.ColorARGB(0xff, 0x70, 0xad, 0x47);
            //series.RisingBarColor = ChartsModel.ColorARGB.Empty;
            //series.FallingBarColor = ChartsModel.ColorARGB.Empty;
            //series.SubtotalBarColor = ChartsModel.ColorARGB.Empty;

            if (series is ChartsModel.ISupportTransparencySeries seriesWithTransparency)
                seriesWithTransparency.Transparency = 0;

            for (int i = 0; i < sampleData.Count; i++) {
                if (sampleData[i].IsTotal)
                    series.Subtotals.Add(i);
            }

            chart.Series.Add(series);

            // Legend
            var legend = new ChartsModel.Legend {
                EnableAntialiasing = DefaultBoolean.True,
                LegendPosition = ChartsModel.LegendPosition.Top,
                Orientation = ChartsModel.LegendOrientation.Horizontal,
                Overlay = false
            };
            chart.Legend = legend;

            // Title
            var title = new ChartsModel.ChartTitle {
                EnableAntialiasing = DefaultBoolean.True,
                Lines = new string[] { "4th Quarter" }
            };
            chart.Titles.Add(title);

            //series.RisingBarColor = new ColorARGB(0xff, 0x4d, 0xbd, 0x61);
            //series.RisingBarFillStyle = new FillStyle() { FillMode = FillMode.Gradient, Options = new FillOptions() { Color2 = new ColorARGB(0xff, 0x91, 0xe2, 0xbf) } };
            series.RisingBarColor = ColorARGB.Transparent;
            series.RisingBarFillStyle = new FillStyle() { FillMode = FillMode.Empty};
            series.SubtotalBarColor = new ColorARGB(0xff, 0xd9, 0xb2, 0x53);
            series.SubtotalBarFillStyle = new FillStyle() { FillMode = FillMode.Gradient, Options = new FillOptions() { Color2 = new ColorARGB(0xff, 0x21, 0xa2, 0xcf) } };

            ChartAppearanceHelper.SetupAppearance(chart);

            return chart;
        }
    }

    public class WaterfallData {
        public WaterfallData(string name, double amount) {
            Name = name;
            Amount = amount;
        }

        public string Name { get; private set; }
        public double Amount { get; private set; }
        public int? PointColor { get; set; }
        public bool IsTotal { get; set; }

        public static List<WaterfallData> GetSampleData() {
            List<WaterfallData> data = new List<WaterfallData> {
                new WaterfallData("Revenue", 23201) { PointColor =  unchecked((int)0xff4472c4) },
                new WaterfallData("Cost of goods", -8273),
                new WaterfallData("Gross margin", 14928) { IsTotal = true },
                new WaterfallData("Administrative expense", -1151),
                new WaterfallData("Net income", 13777) { IsTotal = true }
            };
            return data;
        }
    }
}
