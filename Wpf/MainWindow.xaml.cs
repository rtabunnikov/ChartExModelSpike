using System;
using System.Windows;
using ChartsModel = DevExpress.Charts.Model;
using DevExpress.Xpf.Charts.ModelSupport;
using ChartExModelSpike;
using DevExpress.Xpf.TreeMap;

namespace ChartExWpf {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public enum ChartType {
        BoxWhisker = 0,
        Histogram = 1,
        Funnel = 2,
        Pareto = 3,
        Sunburst = 4,
        TreeMap = 5,
        Waterfall = 6
    }
    public partial class MainWindow : Window {
        private ChartsModel.ModelControllerFactoryBase factory;
        private ChartsModel.IController controller = null;
        private ChartsModel.ChartBase modelChart = null;

        public MainWindow() {
            InitializeComponent();
        }

        private void Reset(ChartType chartType) {
            if (modelChart != null) {
                modelChart = null;
            }
            factory = CreateFactory(chartType);
            controller = factory.CreateController();
        }
        ChartsModel.ModelControllerFactoryBase CreateFactory(ChartType chartType) {
            switch (chartType) {
                case ChartType.BoxWhisker:
                case ChartType.Funnel:
                case ChartType.Histogram:
                case ChartType.Pareto:
                case ChartType.Waterfall:
                    return new XpfChartsModelControllerFactory();
                case ChartType.TreeMap:
                    return new TreeMapModelControllerFactory();
                case ChartType.Sunburst:
                    return new SunburstModelControllerFactory();
                default:
                    throw new ArgumentException("Unknown chart type.");
            }
        }

        private void RenderChart() {
            if (modelChart != null) {
                ChartsModel.ModelRect rect = new ChartsModel.ModelRect(0, 0, viewPanel.ActualWidth, viewPanel.ActualHeight);
                var renderContext = factory.CreateRenderContext(rect, viewPanel);
                controller.RenderChart(renderContext);
            }
        }

        private void viewPanel_SizeChanged(object sender, SizeChangedEventArgs e) => RenderChart();

        private void butWaterfall_Click(object sender, RoutedEventArgs e) {
            Reset(ChartType.Waterfall);
            modelChart = Waterfall.Create();
            controller.ChartModel = modelChart;
            RenderChart();
        }

        private void butBoxWhisker_Click(object sender, RoutedEventArgs e) {
            Reset(ChartType.BoxWhisker);
            modelChart = BoxWhisker.Create();
            controller.ChartModel = modelChart;
            RenderChart();
        }

        private void butFunnel_Click(object sender, RoutedEventArgs e) {
            Reset(ChartType.Funnel);
            modelChart = Funnel.Create();
            controller.ChartModel = modelChart;
            RenderChart();
        }

        private void butHistogram_Click(object sender, RoutedEventArgs e) {
            Reset(ChartType.Histogram);
            modelChart = Histogram.Create();
            controller.ChartModel = modelChart;
            RenderChart();
        }

        private void butPareto_Click(object sender, RoutedEventArgs e) {
            Reset(ChartType.Pareto);
            modelChart = Pareto.Create();
            controller.ChartModel = modelChart;
            RenderChart();
        }

        private void butTreemap_Click(object sender, RoutedEventArgs e) {
            Reset(ChartType.TreeMap);
            modelChart = Treemap.Create();
            controller.ChartModel = modelChart;
            RenderChart();
        }

        private void butSunburst_Click(object sender, RoutedEventArgs e) {
            Reset(ChartType.Sunburst);
            modelChart = Sunburst.Create();
            controller.ChartModel = modelChart;
            RenderChart();
        }
    }
}
