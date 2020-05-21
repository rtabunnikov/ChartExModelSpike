using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChartsModel = DevExpress.Charts.Model;
using DevExpress.XtraCharts.ModelSupport;


namespace ChartExModelSpike {
    public partial class Form1 : Form {
        private readonly XtraChartsModelControllerFactory factory;
        private readonly ChartsModel.Controller controller = null;
        private ChartsModel.Chart modelChart = null;

        public Form1() {
            InitializeComponent();
            factory = new XtraChartsModelControllerFactory();
            controller = factory.CreateController();
        }

        private void View_Paint(object sender, PaintEventArgs e) {
            if(modelChart != null) {
                var graphics = e.Graphics;
                ChartsModel.ModelRect rect = new ChartsModel.ModelRect(8, 8, viewPanel.ClientSize.Width - 16, viewPanel.ClientSize.Height - 16);
                var renderContext = factory.CreateRenderContext(rect, graphics);
                controller.RenderChart(renderContext);
            }
        }

        private void View_SizeChanged(object sender, EventArgs e) { viewPanel.Invalidate(); }

        private void butWaterfall_Click(object sender, EventArgs e) {
            ResetController();
            modelChart = CreateWaterfall();
            controller.ChartModel = modelChart;
            viewPanel.Invalidate();
        }

        private void ResetController() {
            if(modelChart != null) {
                modelChart = null;
                controller.ChartModel = null;
            }
        }

        private ChartsModel.Chart CreateWaterfall() {
            var chart = new ChartsModel.CartesianChart();

            // Argument Axis
            chart.ArgumentAxis = new ChartsModel.Axis()
            {
                Position = ChartsModel.AxisPosition.Bottom,
                GridLinesVisible = false,
                GridLinesMinorVisible = false,
                TickmarksVisible = false,
                Visible = true
            };

            chart.ArgumentAxis.Label = new ChartsModel.AxisLabel(chart.ArgumentAxis) { 
                Visible = true, 
                EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True
            };

            // Value Axis
            chart.ValueAxis = new ChartsModel.Axis()
            {
                Position = ChartsModel.AxisPosition.Left,
                GridLinesVisible = true,
                GridLinesMinorVisible = false,
                TickmarksVisible = true,
                Visible = true
            };

            chart.ValueAxis.Label = new ChartsModel.AxisLabel(chart.ValueAxis) { 
                Visible = true, 
                EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True
            };

            // Series
            var series = new ChartsModel.WaterfallSeries { 
                DisplayName = "Series1", 
                LabelsVisibility = true
            };

            series.DataMembers[ChartsModel.DataMemberType.Argument] = "Name";
            series.DataMembers[ChartsModel.DataMemberType.Value] = "Amount";
            series.DataSource = WaterfallData.GetSampleData();

            series.Label = new ChartsModel.SeriesLabel(series) {
                EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True,
                Position = ChartsModel.SeriesLabelPosition.Top
            };

            chart.Series.Add(series);

            // Legend
            var legend = new ChartsModel.Legend {
                EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True,
                LegendPosition = ChartsModel.LegendPosition.Top,
                Orientation = ChartsModel.LegendOrientation.Horizontal,
                Overlay = false
            };
            chart.Legend = legend;

            // Title
            var title = new ChartsModel.ChartTitle {
                EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True,
                Lines = new string[] { "4th Quarter" }
            };
            chart.Titles.Add(title);

            return chart;
        }
    }
}
