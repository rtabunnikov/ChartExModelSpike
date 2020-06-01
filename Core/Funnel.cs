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
            var chart = new ChartsModel.FunnelChart();

            // Argument Axis
            //chart.ArgumentAxis = new ChartsModel.Axis() {
            //    Position = ChartsModel.AxisPosition.Bottom,
            //    GridLinesVisible = false,
            //    GridLinesMinorVisible = false,
            //    TickmarksVisible = false,
            //    Visible = true
            //};

            //chart.ArgumentAxis.Label = new ChartsModel.AxisLabel(chart.ArgumentAxis) {
            //    EnableAntialiasing = DefaultBoolean.True,
            //    Visible = true
            //};

            // Series
            var series = new ChartsModel.FunnelSeries() {
                DisplayName = "Series 1",
                LabelsVisibility = true
            };

            series.DataMembers[ChartsModel.DataMemberType.Argument] = "Stage";
            series.DataMembers[ChartsModel.DataMemberType.Value] = "Amount";
            series.DataSource = FunnelData.GetSampleData();

            series.Appearance = new ChartsModel.SeriesAppearance() { Color = new ChartsModel.ColorARGB(0xff, 0x44, 0x72, 0xc4) };

            //Data Labels
            series.Label = new ChartsModel.SeriesLabel(series) {
               EnableAntialiasing = DefaultBoolean.True,
               Position = ChartsModel.SeriesLabelPosition.Center
            };
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

            return chart;
        }
    }

    public class FunnelData {
        public FunnelData(string stage, double amount) {
            Stage = stage;
            Amount = amount;
        }

        public string Stage { get; private set; }
        public double Amount { get; private set; }
        //public int PointColor => (int)(Amount >= 0 ? 0xff4472c4 : 0xffed7d31);

        public static List<FunnelData> GetSampleData() {
            List<FunnelData> data = new List<FunnelData>();
            data.Add(new FunnelData("Prospects", 500));
            data.Add(new FunnelData("Qualified prospects", 425));
            data.Add(new FunnelData("Need analysis", 200));
            data.Add(new FunnelData("Price quotes", 150));
            data.Add(new FunnelData("Negotiations", 100));
            data.Add(new FunnelData("Closed sales", 90));
            return data;
        }
    }
}
