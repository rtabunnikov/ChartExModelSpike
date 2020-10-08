using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChartsModel = DevExpress.Charts.Model;
using DevExpress.Utils;

namespace ChartExModelSpike {
    public static class Pareto {
        public static ChartsModel.Chart Create() {
            var chart = new ChartsModel.CartesianChart();

            // Argument Axis
            chart.ArgumentAxis = new ChartsModel.Axis() {
                Position = ChartsModel.AxisPosition.Bottom,
                GridLinesVisible = false,
                GridLinesMinorVisible = false,
                TickmarksVisible = false,
                Visible = true,
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

            // Secondary Value Axis
            var secondaryAxis = new ChartsModel.Axis() {
                Position = ChartsModel.AxisPosition.Right,
                GridLinesVisible = false,
                GridLinesMinorVisible = false,
                TickmarksVisible = true,
                Visible = true,
            };
            chart.SecondaryValueAxes.Add(secondaryAxis);

            secondaryAxis.Label = new ChartsModel.AxisLabel(secondaryAxis) {
                EnableAntialiasing = DefaultBoolean.True,
                Formatter = new PercentageFormatter(),
                Visible = true
            };

            secondaryAxis.Range = new ChartsModel.AxisRange(secondaryAxis) {
                MinValue = 0,
                MaxValue = 1
            };

            // Series
            var series = new ChartsModel.SideBySideBarSeries {
                DisplayName = "Amount",
                LabelsVisibility = true,
                BarWidth = 1
            };

            var sampleData = ParetoData.GetSampleData();
            series.DataMembers[ChartsModel.DataMemberType.Argument] = "Name";
            series.DataMembers[ChartsModel.DataMemberType.Value] = "Amount";
            series.DataSource = sampleData;

            series.Appearance = new ChartsModel.SeriesAppearance() {
                Color = new ChartsModel.ColorARGB(0xff, 0x44, 0x72, 0xc4),
                LabelAppearance = new ChartsModel.SeriesLabelAppearance() {
                    LineVisible = false,
                    Border = new ChartsModel.Border() { Color = ChartsModel.ColorARGB.Transparent },
                    TextColor = new ChartsModel.ColorARGB(255, 255, 255, 255),
                    BackColor = ChartsModel.ColorARGB.Transparent
                },
            };

            series.Label = new ChartsModel.SeriesLabel(series) {
                EnableAntialiasing = DefaultBoolean.True,
                Position = ChartsModel.SeriesLabelPosition.InsideEnd
            };


            if (series is ChartsModel.ISupportTransparencySeries seriesWithTransparency)
                seriesWithTransparency.Transparency = 0;

            chart.Series.Add(series);

            // Pareto line
            var paretoLine = new ChartsModel.LineSeries {
                DisplayName = "Pareto line",
                LabelsVisibility = false,
            };

            paretoLine.DataMembers[ChartsModel.DataMemberType.Argument] = "Name";
            paretoLine.DataMembers[ChartsModel.DataMemberType.Value] = "CumulativePercentage";
            paretoLine.DataSource = sampleData;
            paretoLine.SecondaryValueAxisIndex = 0;

            paretoLine.Appearance = new ChartsModel.SeriesAppearance() {
                Color = new ChartsModel.ColorARGB(0xff, 0xed, 0x7d, 0x31),
            };

            chart.Series.Add(paretoLine);

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
                Lines = new string[] { "Pareto" }
            };
            chart.Titles.Add(title);

            ChartAppearanceHelper.SetupAppearance(chart);

            return chart;
        }
    }

    public class ParetoData {
        public ParetoData(string name, double amount) {
            Name = name;
            Amount = amount;
        }

        public string Name { get; private set; }
        public double Amount { get; private set; }
        public double CumulativePercentage { get; set; }

        public static List<ParetoData> GetSampleData() {
            List<ParetoData> data = new List<ParetoData> {
                new ParetoData("CatA", 20000),
                new ParetoData("CatB", 18000),
                new ParetoData("CatC", 5000),
                new ParetoData("CatD", 24000),
                new ParetoData("CatE", 16000),
            };
            data.Sort((x, y) => y.Amount.CompareTo(x.Amount));
            double total = data.Sum(x => x.Amount);
            double current = 0;
            foreach (var item in data) {
                current += item.Amount;
                item.CumulativePercentage = current / total;
            }
            return data;
        }
    }

    class PercentageFormatter : ChartsModel.IAxisLabelFormatter {
        public string GetAxisLabelText(object axisValue) {
            double value = (double)axisValue;
            return value.ToString("P0");
        }
    }
}
