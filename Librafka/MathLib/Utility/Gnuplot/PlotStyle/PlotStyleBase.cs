﻿namespace Librafka.MathLib.Utility {
  public partial struct PlotStyle {
    public LineType LineType { get; set; }
    public PlotColor PlotColor { get; set; }
    public uint LineWidth { get; set; }
    public PointType PointType { get; set; }
    public uint PointSize { get; set; }

    public void Initialize() {
      LineType = LineType.Solid;
      PlotColor = PlotColor.Red;
      LineWidth = 1;
      PointType = PointType.FilledCircle;
      PointSize = 1;
    }
  }
}