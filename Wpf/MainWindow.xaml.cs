using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChartsModel = DevExpress.Charts.Model;
using DevExpress.Xpf.Charts.ModelSupport;
using ChartExModelSpike;
using DevExpress.Xpf.TreeMap;

namespace ChartExWpf {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private readonly XpfChartsModelControllerFactory factory;
        private ChartsModel.Controller controller = null;
        private ChartsModel.Chart modelChart = null;

        private readonly TreeMapModelControllerFactory treeMapFactory;
        private TreeMapController treeMapController = null;
        private ChartsModel.TreeMap treeMapChart = null;

        public MainWindow() {
            InitializeComponent();
            factory = new XpfChartsModelControllerFactory();
            controller = factory.CreateController();
            treeMapFactory = new TreeMapModelControllerFactory();
            treeMapController = (TreeMapController)treeMapFactory.CreateController();
        }

        private void ResetController() {
            if (modelChart != null) {
                modelChart = null;
                controller.ChartModel = null;
                controller = factory.CreateController();
            }
            if (treeMapChart != null) {
                treeMapChart = null;
                treeMapController.ChartModel = null;
                treeMapController = (TreeMapController)treeMapFactory.CreateController();
            }
        }

        private void RenderChart() {
            if (modelChart != null) {
                ChartsModel.ModelRect rect = new ChartsModel.ModelRect(0, 0, viewPanel.ActualWidth, viewPanel.ActualHeight);
                var renderContext = factory.CreateRenderContext(rect, viewPanel);
                controller.RenderChart(renderContext);
            }
            else if (treeMapChart != null) {
                ChartsModel.ModelRect rect = new ChartsModel.ModelRect(0, 0, viewPanel.ActualWidth, viewPanel.ActualHeight);
                var renderContext = treeMapFactory.CreateRenderContext(rect, viewPanel);
                treeMapController.RenderChart(renderContext);
            }
        }

        private void viewPanel_SizeChanged(object sender, SizeChangedEventArgs e) => RenderChart();

        private void butWaterfall_Click(object sender, RoutedEventArgs e) {
            ResetController();
            modelChart = Waterfall.Create();
            controller.ChartModel = modelChart;
            RenderChart();
        }

        private void butBoxWhisker_Click(object sender, RoutedEventArgs e) {
            ResetController();
            modelChart = BoxWhisker.Create();
            controller.ChartModel = modelChart;
            RenderChart();
        }

        private void butFunnel_Click(object sender, RoutedEventArgs e) {
            ResetController();
            modelChart = Funnel.Create();
            controller.ChartModel = modelChart;
            RenderChart();
        }

        private void butHistogram_Click(object sender, RoutedEventArgs e) {
            ResetController();
            modelChart = Histogram.Create();
            controller.ChartModel = modelChart;
            RenderChart();
        }

        private void butPareto_Click(object sender, RoutedEventArgs e) {
            ResetController();
            modelChart = Pareto.Create();
            controller.ChartModel = modelChart;
            RenderChart();
        }

        private void butTreemap_Click(object sender, RoutedEventArgs e) {
            ResetController();
            treeMapChart = Treemap.Create();
            treeMapController.TreeMapModel = treeMapChart;
            RenderChart();
        }
    }
}
