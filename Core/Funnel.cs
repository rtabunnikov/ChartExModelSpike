using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChartsModel = DevExpress.Charts.Model;
using DevExpress.Utils;

namespace ChartExModelSpike {
    public static class Funnel {
        public static ChartsModel.Chart Create() {
            var chart = new ChartsModel.CartesianChart();
            chart.Rotated = true;

            // Argument Axis
            chart.ArgumentAxis = new ChartsModel.Axis() {
                Position = ChartsModel.AxisPosition.Bottom,
                GridLinesVisible = false,
                GridLinesMinorVisible = false,
                TickmarksVisible = false,
                Reverse = true,
                Visible = true
            };

            chart.ArgumentAxis.Label = new ChartsModel.AxisLabel(chart.ArgumentAxis) {
                EnableAntialiasing = DefaultBoolean.True,
                Visible = true
            };

            chart.ValueAxis = new ChartsModel.Axis() {
                Position = ChartsModel.AxisPosition.Left,
                GridLinesVisible = false,
                GridLinesMinorVisible = false,
                TickmarksVisible = false,
                Visible = false
            };

            chart.ValueAxis.Label = new ChartsModel.AxisLabel(chart.ArgumentAxis) {
                EnableAntialiasing = DefaultBoolean.True,
                Visible = false
            };

            // Series
            var series = new ChartsModel.RangeBarSeries() {
                DisplayName = "Series 1",
                LabelsVisibility = true,
                BarWidth = 1.0 / (1.0 + 0.25) // 25% gap
            }; 

            series.DataMembers[ChartsModel.DataMemberType.Argument] = "Stage";
            series.DataMembers[ChartsModel.DataMemberType.Value] = "Amount";
            series.DataMembers[ChartsModel.DataMemberType.Value2] = "NegAmount";
            series.DataMembers[ChartsModel.DataMemberType.Color] = "PointColor";
            series.DataSource = FunnelData.GetSampleData();

            //series.Appearance = new ChartsModel.SeriesAppearance() { Color = new ChartsModel.ColorARGB(0xff, 0x44, 0x72, 0xc4) };
            series.Appearance = new ChartsModel.SeriesAppearance();
            series.Appearance.FillStyle = new ChartsModel.FillStyle() { FillMode = ChartsModel.FillMode.Solid };
            series.Appearance.Color = new ChartsModel.ColorARGB(0xff, 0xff, 0, 0);

            //Data Labels
            // UNCOMMENT for InvalidCastException under WinForms
            //series.Label = new ChartsModel.SeriesLabel(series) {
            //    EnableAntialiasing = DefaultBoolean.True,
            //    Position = ChartsModel.SeriesLabelPosition.Center
            //};

            series.Appearance.LabelAppearance = new ChartsModel.SeriesLabelAppearance() {
                LineVisible = false,
                Border = new ChartsModel.Border() { Color = ChartsModel.ColorARGB.Transparent },
                TextColor = new ChartsModel.ColorARGB(0xff, 0xff, 0xff, 0xff),
                BackColor = ChartsModel.ColorARGB.Transparent
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
                Lines = new string[] { "Sales Pipeline" }
            };
            chart.Titles.Add(title);

            ChartAppearanceHelper.SetupAppearance(chart);
            chart.Appearance.DiagramAppearance.BorderVisible = false;

            return chart;            
            
            //var chart = new ChartsModel.FunnelChart();

            //// Argument Axis
            ////chart.ArgumentAxis = new ChartsModel.Axis() {
            ////    Position = ChartsModel.AxisPosition.Bottom,
            ////    GridLinesVisible = false,
            ////    GridLinesMinorVisible = false,
            ////    TickmarksVisible = false,
            ////    Visible = true
            ////};

            ////chart.ArgumentAxis.Label = new ChartsModel.AxisLabel(chart.ArgumentAxis) {
            ////    EnableAntialiasing = DefaultBoolean.True,
            ////    Visible = true
            ////};

            //// Series
            //var series = new ChartsModel.FunnelSeries() {
            //    DisplayName = "Series 1",
            //    LabelsVisibility = true,
            //    PointShape = ChartsModel.FunnelPointShape.Rectangle
            //};

            //series.DataMembers[ChartsModel.DataMemberType.Argument] = "Stage";
            //series.DataMembers[ChartsModel.DataMemberType.Value] = "Amount";
            //series.DataMembers[ChartsModel.DataMemberType.Color] = "PointColor";
            //series.DataSource = FunnelData.GetSampleData();

            ////series.Appearance = new ChartsModel.SeriesAppearance() { Color = new ChartsModel.ColorARGB(0xff, 0x44, 0x72, 0xc4) };
            //series.Appearance = new ChartsModel.SeriesAppearance();
            //series.Appearance.FillStyle = new ChartsModel.FillStyle() { FillMode = ChartsModel.FillMode.Solid };
            //series.Appearance.Color = new ChartsModel.ColorARGB(0xff, 0xff, 0, 0);

            ////Data Labels
            //series.Label = new ChartsModel.SeriesLabel(series) {
            //   EnableAntialiasing = DefaultBoolean.True,
            //   Position = ChartsModel.SeriesLabelPosition.Center
            //};
            //series.Appearance.LabelAppearance = new ChartsModel.SeriesLabelAppearance() {
            //    LineVisible = false,
            //    Border = new ChartsModel.Border() { Color = ChartsModel.ColorARGB.Transparent },
            //    TextColor = new ChartsModel.ColorARGB(0xff, 0xff, 0xff, 0xff),
            //    BackColor = ChartsModel.ColorARGB.Transparent
            //};

            //if (series is ChartsModel.ISupportTransparencySeries seriesWithTransparency)
            //    seriesWithTransparency.Transparency = 0;

            //chart.Series.Add(series);

            //// Legend
            //var legend = new ChartsModel.Legend {
            //    EnableAntialiasing = DefaultBoolean.True,
            //    LegendPosition = ChartsModel.LegendPosition.Top,
            //    Orientation = ChartsModel.LegendOrientation.Horizontal,
            //    Overlay = false
            //};
            //chart.Legend = legend;

            //// Title
            //var title = new ChartsModel.ChartTitle {
            //    EnableAntialiasing = DefaultBoolean.True,
            //    Lines = new string[] { "Sales Pipeline" }
            //};
            //chart.Titles.Add(title);

            //ChartAppearanceHelper.SetupAppearance(chart);

            //return chart;
        }
    }

    public class FunnelData {
        public FunnelData(string stage, double amount) {
            Stage = stage;
            Amount = amount;
            PointColor = null;
        }

        public string Stage { get; private set; }
        public double Amount { get; private set; }
        public double NegAmount => -Amount;
        public int? PointColor { get; set; }

        public static List<FunnelData> GetSampleData() {
            List<FunnelData> data = new List<FunnelData> {
                new FunnelData("Prospects", 500)/* { PointColor = unchecked((int)0xff4472c4) }*/,
                new FunnelData("Qualified prospects", 425) { PointColor = unchecked((int)0xffed7d31) },
                new FunnelData("Need analysis", 200) { PointColor = unchecked((int)0xffa5a5a5) },
                new FunnelData("Price quotes", 150) { PointColor = unchecked((int)0xffffc000) },
                new FunnelData("Negotiations", 100) { PointColor = unchecked((int)0xff5898d5) },
                new FunnelData("Closed sales", 90) { PointColor = unchecked((int)0xff70ad47) }
            };
            return data;
        }
    }
}
