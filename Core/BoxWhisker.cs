using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChartsModel = DevExpress.Charts.Model;
using DevExpress.Utils;

namespace ChartExModelSpike {
    public static class BoxWhisker {
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
                AutoGrid = false,
                GridLinesVisible = true,
                GridLinesMinorVisible = false,
                GridSpacing = 5,
                GridSpacingFactor = 30,
                TickmarksVisible = true,
                Visible = true
            };

            chart.ValueAxis.Label = new ChartsModel.AxisLabel(chart.ValueAxis) {
                EnableAntialiasing = DefaultBoolean.True,
                Visible = true
            };

            chart.ValueAxis.Range = new ChartsModel.AxisRange(chart.ValueAxis) {
                MinValue = 40,
                MaxValue = 70
            };

            // Series
            for (int i = 0; i < 3; i++) {
                var series = new ChartsModel.BoxPlotSeries() {
                    DisplayName = $"School {i + 1}",
                    LabelsVisibility = i == 0
                };

                series.DataMembers[ChartsModel.DataMemberType.Argument] = "Name";
                series.DataMembers[ChartsModel.DataMemberType.BoxPlotMin] = "Min";
                series.DataMembers[ChartsModel.DataMemberType.BoxPlotQuartile1] = "Quartile1";
                series.DataMembers[ChartsModel.DataMemberType.BoxPlotMedian] = "Median";
                series.DataMembers[ChartsModel.DataMemberType.BoxPlotQuartile3] = "Quartile3";
                series.DataMembers[ChartsModel.DataMemberType.BoxPlotMax] = "Max";
                series.DataMembers[ChartsModel.DataMemberType.BoxPlotMean] = "Mean";
                series.DataMembers[ChartsModel.DataMemberType.BoxPlotOutliers] = "Outliers";
                series.DataSource = BoxWhiskerData.GetSampleData(i);

                series.Appearance = new ChartsModel.SeriesAppearance() { Color = GetSeriesColor(i) };

                if (i == 0) {
                    // DATA LABELS?????
                    //series.Label = new ChartsModel.SeriesLabel(series) {
                    //    EnableAntialiasing = DefaultBoolean.True,
                    //    Position = ChartsModel.SeriesLabelPosition.Top
                    //};
                    //series.Appearance.LabelAppearance = new ChartsModel.SeriesLabelAppearance() {
                    //    LineVisible = false,
                    //    Border = new ChartsModel.Border() { Color = ChartsModel.ColorARGB.Transparent },
                    //    TextColor = new ChartsModel.ColorARGB(255, 0, 0, 0),
                    //    BackColor = ChartsModel.ColorARGB.Transparent
                    //};
                }

                if (series is ChartsModel.ISupportTransparencySeries seriesWithTransparency)
                    seriesWithTransparency.Transparency = 0;

                chart.Series.Add(series);

                if (i == 1) {
                    var meanLine = new ChartsModel.LineSeries();
                    meanLine.DataMembers[ChartsModel.DataMemberType.Argument] = "Name";
                    meanLine.DataMembers[ChartsModel.DataMemberType.Value] = "Mean";
                    meanLine.DataSource = BoxWhiskerData.GetSampleData(i);
                    meanLine.LabelsVisibility = false;
                    meanLine.Appearance = new ChartsModel.SeriesAppearance() { Color = new ChartsModel.ColorARGB(0xff, 0xcb, 0x5c, 0x20) };
                    meanLine.Appearance.LineStyle = new ChartsModel.LineStyle() { Thickness = 1, DashStyle = ChartsModel.DashStyle.Solid };
                    chart.Series.Add(meanLine);
                }
            }

            // Legend
            var legend = new ChartsModel.Legend {
                EnableAntialiasing = DefaultBoolean.True,
                LegendPosition = ChartsModel.LegendPosition.Right,
                Orientation = ChartsModel.LegendOrientation.Vertical,
                Overlay = false
            };
            chart.Legend = legend;

            // Title
            var title = new ChartsModel.ChartTitle {
                EnableAntialiasing = DefaultBoolean.True,
                Lines = new string[] { "Course by schools" }
            };
            chart.Titles.Add(title);

            ChartAppearanceHelper.SetupAppearance(chart);

            return chart;
        }

        static ChartsModel.ColorARGB GetSeriesColor(int index) {
            if (index == 0) return new ChartsModel.ColorARGB(0xff, 0x44, 0x72, 0xc4);
            if (index == 1) return new ChartsModel.ColorARGB(0xff, 0xed, 0x7d, 0x31);
            return new ChartsModel.ColorARGB(0xff, 0xa5, 0xa5, 0xa5);
        }
    }

    public class BoxWhiskerData {
        public BoxWhiskerData(string name, double min, double quartile1, double median, double quartile3, double max, double mean) {
            Name = name;
            Min = min;
            Quartile1 = quartile1;
            Median = median;
            Quartile3 = quartile3;
            Max = max;
            Mean = mean;
            Outliers = new List<double>();
        }

        public string Name { get; set; }
        public double Min { get; set; }
        public double Quartile1 { get; set; }
        public double Median { get; set; }
        public double Quartile3 { get; set; }
        public double Max { get; set; }
        public double Mean { get; set; }
        public List<double> Outliers { get; set;  }

        public static List<BoxWhiskerData> GetSampleData(int seriesIndex) {
            var data = new List<BoxWhiskerData>();
            if (seriesIndex == 0) {
                data.Add(new BoxWhiskerData("English", 58, 58.25, 61.5, 63, 63, 59.375) { Outliers = new List<double>() { 46 } });
                data.Add(new BoxWhiskerData("Physics", 60, 60, 60.5, 61, 61, 60.5));
                data.Add(new BoxWhiskerData("Math", 60, 60.5, 62, 62.5, 63, 61.5));
            }
            else if (seriesIndex == 1) {
                data.Add(new BoxWhiskerData("English", 50, 52.25, 53.5, 55.5, 56, 53.5));
                data.Add(new BoxWhiskerData("Physics", 55, 55, 55.5, 56, 56, 55.5));
                data.Add(new BoxWhiskerData("Math", 51, 51, 53, 57, 58, 53.8));
            }
            else {
                data.Add(new BoxWhiskerData("English", 63.25, 64, 64.25, 65.5, 67, 63.25) { Outliers = new List<double>() { 45, 69 } });
                data.Add(new BoxWhiskerData("Physics", 64, 64, 64.5, 65, 65, 64.5));
                data.Add(new BoxWhiskerData("Math", 45, 54.5, 64, 66.5, 67, 61.2));
            }
            return data;
        }
    }
}
