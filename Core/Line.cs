using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChartsModel = DevExpress.Charts.Model;
using DevExpress.Utils;
using DevExpress.Charts.Model;

namespace ChartExModelSpike {
    public static class Line {
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
            var series = new ChartsModel.LineSeries {
                DisplayName = "Series1",
                LabelsVisibility = true,
                ColorEach = true
            };

            var sampleData = LineData.GetSampleData();
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
                LineStyle = new LineStyle() { Thickness = 3, DashStyle = DashStyle.Solid },
                LabelAppearance = new ChartsModel.SeriesLabelAppearance() {
                    LineVisible = false,
                    Border = new ChartsModel.Border() { Color = ChartsModel.ColorARGB.Transparent },
                    TextColor = new ChartsModel.ColorARGB(255, 0, 0, 0),
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
                Lines = new string[] { "ChartTitle" }
            };
            chart.Titles.Add(title);

            ChartAppearanceHelper.SetupAppearance(chart);

            return chart;
        }
    }
    public class LineData {
        public LineData(string name, double amount) {
            Name = name;
            Amount = amount;
        }

        public string Name { get; private set; }
        public double Amount { get; private set; }
        public int? PointColor { get; set; }

        public static List<LineData> GetSampleData() {
            var data = new List<LineData> {
                new LineData("a", 5) { PointColor = unchecked((int)0xff0000ff) },
                new LineData("b", 2) { PointColor = unchecked((int)0xff0000ff) },
                new LineData("c", 4) { PointColor = unchecked((int)0x00000000) },
                new LineData("d", 7) { PointColor = unchecked((int)0xffff0000) },
                new LineData("e", 3) { PointColor = unchecked((int)0xffff0000) },
                new LineData("f", 10) { PointColor = unchecked((int)0x00000000) },
                new LineData("g", 4) { PointColor = unchecked((int)0xff00ff00) },
                new LineData("h", 9) { PointColor = unchecked((int)0xff00ff00) },
            };
            return data;
        }
    }
}
