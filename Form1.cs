using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChartsModel = DevExpress.Charts.Model;
using DevExpress.XtraCharts.ModelSupport;
using DevExpress.Charts.Model;

namespace ChartExModelSpike {
    public partial class Form1 : Form {
        private readonly XtraChartsModelControllerFactory factory;
        private ChartsModel.Controller controller = null;
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
                controller = factory.CreateController();
            }
        }

        private void butBoxWhisker_Click(object sender, EventArgs e) {
            ResetController();
            modelChart = CreateBoxWhisker();
            controller.ChartModel = modelChart;
            viewPanel.Invalidate();
        }
    }
}
