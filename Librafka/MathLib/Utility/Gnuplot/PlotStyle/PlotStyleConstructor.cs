namespace Librafka.MathLib.Utility {
  public partial struct PlotStyle {
    public PlotStyle(LineType lt) {
      LineType = lt;
      PlotColor = PlotColor.Red;
      LineWidth = 1;
      PointType = PointType.FilledCircle;
      PointSize = 1;
    }
  }
}