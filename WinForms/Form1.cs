using System;
using System.Windows.Forms;
using ChartsModel = DevExpress.Charts.Model;
using DevExpress.XtraCharts.ModelSupport;
using DevExpress.XtraTreeMap.Native;
using DevExpress.Charts.Model;

namespace ChartExModelSpike {
    public enum ChartType {
        BoxWhisker = 0,
        Histogram = 1,
        Funnel = 2,
        Pareto = 3,
        Sunburst = 4,
        TreeMap = 5,
        Waterfall = 6
    }

    public partial class Form1 : Form {
        private ModelControllerFactoryBase factory;
        private ChartsModel.IController controller = null;
        private ChartsModel.ChartBase modelChart = null;

        public Form1() {
            InitializeComponent();
        }

        private void View_Paint(object sender, PaintEventArgs e) {
            if (modelChart != null) {
                var graphics = e.Graphics;
                ChartsModel.ModelRect rect = new ChartsModel.ModelRect(8, 8, viewPanel.ClientSize.Width - 16, viewPanel.ClientSize.Height - 16);
                var renderContext = factory.CreateRenderContext(rect, graphics);
                controller.RenderChart(renderContext);
            }
        }

        private void View_SizeChanged(object sender, EventArgs e) => viewPanel.Invalidate();

        private void Reset(ChartType chartType) {
            if (modelChart != null) {
                modelChart = null;
            }
            factory = CreateFactory(chartType);
            controller = factory.CreateController();
        }
        ModelControllerFactoryBase CreateFactory(ChartType chartType) {
            switch (chartType) {
                case ChartType.BoxWhisker:
                case ChartType.Funnel:
                case ChartType.Histogram:
                case ChartType.Pareto:
                case ChartType.Waterfall:
                    return new XtraChartsModelControllerFactory();
                case ChartType.TreeMap:
                case ChartType.Sunburst:
                    return new TreeModelControllerFactory();
                default:
                    throw new ArgumentException("Unknown chart type.");
            }
        }

        private void butWaterfall_Click(object sender, EventArgs e) {
            Reset(ChartType.Waterfall);
            modelChart = Waterfall.Create();
            controller.ChartModel = modelChart;
            viewPanel.Invalidate();
        }

        private void butBoxWhisker_Click(object sender, EventArgs e) {
            Reset(ChartType.BoxWhisker);
            modelChart = BoxWhisker.Create();
            controller.ChartModel = modelChart;
            viewPanel.Invalidate();
        }

        private void butFunnel_Click(object sender, EventArgs e) {
            Reset(ChartType.Funnel);
            modelChart = Funnel.Create();
            controller.ChartModel = modelChart;
            viewPanel.Invalidate();
        }

        private void butHistogram_Click(object sender, EventArgs e) {
            Reset(ChartType.Histogram);
            modelChart = Histogram.Create();
            controller.ChartModel = modelChart;
            viewPanel.Invalidate();
        }

        private void butPareto_Click(object sender, EventArgs e) {
            Reset(ChartType.Pareto);
            modelChart = Pareto.Create();
            controller.ChartModel = modelChart;
            viewPanel.Invalidate();
        }

        private void butTreemap_Click(object sender, EventArgs e) {
            Reset(ChartType.TreeMap);
            modelChart = Treemap.Create();
            controller.ChartModel = modelChart;
            viewPanel.Invalidate();
        }
    }
}
