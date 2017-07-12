namespace Librafka.MathLib.Utility {
  public partial struct PlotStyle {
    public PlotStyle(LineType lt) : this() {
      LineType = lt;
    }

    public PlotStyle(PlotColor pc) {
      LineType = LineType.Solid;
      PlotColor = pc;
      LineWidth = 1;
    }
  }
}