using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChartsModel = DevExpress.Charts.Model;
using DevExpress.Utils;

namespace ChartExModelSpike {
    partial class Form1 {
        private ChartsModel.Chart CreateBoxWhisker() {
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

            return chart;
        }

        ChartsModel.ColorARGB GetSeriesColor(int index) {
            if (index == 0) return new ChartsModel.ColorARGB(0xff, 0x44, 0x72, 0xc4);
            if (index == 1) return new ChartsModel.ColorARGB(0xff, 0xed, 0x7d, 0x31);
            return new ChartsModel.ColorARGB(0xff, 0xa5, 0xa5, 0xa5);
        }
    }
}
