using DevExpress.Charts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChartsModel = DevExpress.Charts.Model;

namespace ChartExModelSpike {
    public static class ChartAppearanceHelper {
        public static void SetupAppearance(ChartsModel.Chart chart) {
            chart.Appearance = new ChartAppearanceOptions();
            // Chart appearance
            chart.Appearance.ChartAppearance = new ChartAppearance() {
                BackColor = GetColor(0xffff),
                Border = new Border() {
                    Color = GetColor(0xf999),
                    Thickness = 1
                },
                FillStyle = new FillStyle() { FillMode = FillMode.Solid },
                Padding = new RectangleIndents(5),
                TitleAppearance = new ChartTitleAppearance() {
                    TextColor = GetColor(0xf333)
                }
            };
            // Diagram appearance
            chart.Appearance.DiagramAppearance = new DiagramAppearance() {
                BackColor = GetColor(0xffff),
                BorderColor = GetColor(0xf999),
                BorderVisible = true,
                FillStyle = new FillStyle() { FillMode = FillMode.Solid },
                AxesAppearance = new AxisAppearance() {
                    Interlaced = false,
                    Color = GetColor(0xf999),
                    GridLinesColor = GetColor(0xf999),
                    GridLinesLineStyle = new LineStyle() { 
                        DashStyle = DashStyle.Solid,
                        Thickness = 1 
                    },
                    GridLinesMinorColor = GetColor(0xfccc),
                    LabelTextColor = GetColor(0xf111),
                },
            };
            // Legend appearance
            chart.Appearance.LegendAppearance = new LegendAppearance() {
                BackColor = ColorARGB.Transparent,
                Border = new Border() { Color = ColorARGB.Transparent },
                TextColor = GetColor(0xf111)
            };
        }

        static ColorARGB GetColor(ushort argb) {
            byte a = (byte)((argb & 0xf000) >> 12 | (argb & 0xf000) >> 8);
            byte r = (byte)((argb & 0x0f00) >> 8 | (argb & 0x0f00) >> 4);
            byte g = (byte)((argb & 0x00f0) >> 4 | (argb & 0x00f0));
            byte b = (byte)((argb & 0x000f) << 4 | (argb & 0x000f));
            return new ColorARGB(a, r, g, b);
        }
    }
}
