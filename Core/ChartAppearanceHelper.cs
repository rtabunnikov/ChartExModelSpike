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
                BackColor = GetColor(0xffffffff),
                Border = new Border() {
                    Color = GetColor(0xff999999),
                    Thickness = 1
                },
                FillStyle = new FillStyle() { FillMode = FillMode.Solid },
                Padding = new RectangleIndents(5),
                TitleAppearance = new ChartTitleAppearance() {
                    TextColor = GetColor(0xff666666)
                }
            };
            // Diagram appearance
            chart.Appearance.DiagramAppearance = new DiagramAppearance() {
                BackColor = GetColor(0xffffffff),
                BorderColor = GetColor(0xff999999),
                BorderVisible = true,
                FillStyle = new FillStyle() { FillMode = FillMode.Solid },
                AxesAppearance = new AxisAppearance() {
                    Interlaced = false,
                    Color = GetColor(0xff999999),
                    GridLinesColor = GetColor(0xff999999),
                    GridLinesMinorColor = GetColor(0xffcccccc),
                    LabelTextColor = GetColor(0xff333333),
                }
            };
            // Legend appearance
            chart.Appearance.LegendAppearance = new LegendAppearance() {
                BackColor = ColorARGB.Transparent,
                Border = new Border() { Color = ColorARGB.Transparent },
            };
        }

        static ColorARGB GetColor(uint argb) => new ColorARGB(
            (byte)((argb & 0xff000000) >> 24), 
            (byte)((argb & 0x00ff0000) >> 16), 
            (byte)((argb & 0x0000ff00) >> 8), 
            (byte)(argb & 0x000000ff));
    }
}
