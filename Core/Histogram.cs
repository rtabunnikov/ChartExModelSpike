using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChartsModel = DevExpress.Charts.Model;
using DevExpress.Utils;

namespace ChartExModelSpike {
    public static class Histogram {
        public static ChartsModel.Chart Create() {
            var chart = new ChartsModel.CartesianChart();

            // Argument Axis
            chart.ArgumentAxis = new ChartsModel.Axis() {
                Position = ChartsModel.AxisPosition.Bottom,
                GridLinesVisible = false,
                GridLinesMinorVisible = false,
                TickmarksVisible = false,
                Visible = true,
                IntervalOptions = new ChartsModel.ModelIntervalOptions() {
                    DivisionMode = ChartsModel.IntervalDivisionMode.Count,
                    Count = 4,
                    Width = 5,
                    OverflowValue = 16,
                    UnderflowValue = 3,
                    //OverflowValue = new DateTime(2020, 6, 27),
                    //UnderflowValue = new DateTime(2020, 6, 4),
                }
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
            var series = new ChartsModel.SideBySideBarSeries {
                DisplayName = "Series1",
                LabelsVisibility = true,
                BarWidth = 1
            };

            var sampleData = HistogramData.GetSampleData();
            // By category
            //series.DataMembers[ChartsModel.DataMemberType.Argument] = "Name";
            //series.DataMembers[ChartsModel.DataMemberType.Value] = "Score";
            // Binning
            series.DataMembers[ChartsModel.DataMemberType.Argument] = "Score";
            // DateTime
            //series.DataMembers[ChartsModel.DataMemberType.Argument] = "Date";

            series.DataSource = sampleData;

            //series.Label = new ChartsModel.SeriesLabel(series) {
            //    EnableAntialiasing = DefaultBoolean.True,
            //    Position = ChartsModel.SeriesLabelPosition.Top
            //};
            series.Appearance = new ChartsModel.SeriesAppearance() {
                Color = new ChartsModel.ColorARGB(0xff, 0x44, 0x72, 0xc4),
                LabelAppearance = new ChartsModel.SeriesLabelAppearance() {
                    LineVisible = false,
                    Border = new ChartsModel.Border() { Color = ChartsModel.ColorARGB.Transparent },
                    TextColor = new ChartsModel.ColorARGB(255, 255, 255, 255),
                    BackColor = ChartsModel.ColorARGB.Transparent
                },
            };


            if (series is ChartsModel.ISupportTransparencySeries seriesWithTransparency)
                seriesWithTransparency.Transparency = 0;

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
                Lines = new string[] { "Scores" }
            };
            chart.Titles.Add(title);

            ChartAppearanceHelper.SetupAppearance(chart);

            return chart;
        }
    }

    public class HistogramData {
        public HistogramData(string name, double score, DateTime date) {
            Name = name;
            Score = score;
            Date = date;
        }

        public string Name { get; private set; }
        public double Score { get; private set; }
        public DateTime Date { get; private set; }

        public static List<HistogramData> GetSampleData() {
            List<HistogramData> data = new List<HistogramData> {
                new HistogramData("Pane", 12, new DateTime(2020, 6, 10)),
                new HistogramData("Vino", 7, new DateTime(2020, 6, 25)),
                new HistogramData("Formaggio", 10, new DateTime(2020, 6, 1)),
                new HistogramData("Pane", 5, new DateTime(2020, 6, 6)),
                new HistogramData("Vino", 17, new DateTime(2020, 6, 10)),
                new HistogramData("Formaggio", 3, new DateTime(2020, 6, 17)),
                new HistogramData("Pane", 10, new DateTime(2020, 6, 12)),
                new HistogramData("Vino", 2, new DateTime(2020, 6, 12)),
                new HistogramData("Formaggio", 15, new DateTime(2020, 6, 10)),
                new HistogramData("Pane", 14, new DateTime(2020, 6, 14)),
                new HistogramData("Vino", 9, new DateTime(2020, 6, 10)),
                new HistogramData("Formaggio", 11, new DateTime(2020, 6, 6)),
                new HistogramData("Pane", 14, new DateTime(2020, 6, 4)),
                new HistogramData("Vino", 4, new DateTime(2020, 6, 17)),
                new HistogramData("Formaggio", 1, new DateTime(2020, 6, 15)),
                new HistogramData("Pane", 12, new DateTime(2020, 6, 18)),
                new HistogramData("Vino", 19, new DateTime(2020, 6, 22)),
                new HistogramData("Formaggio", 6, new DateTime(2020, 6, 30)),
            };
            return data;
        }
    }
}
