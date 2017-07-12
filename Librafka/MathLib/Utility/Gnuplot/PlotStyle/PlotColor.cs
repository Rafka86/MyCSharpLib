namespace Librafka.MathLib.Utility {
  public struct PlotColor {
    public static readonly PlotColor Red = new PlotColor(255, 0, 0);
    public static readonly PlotColor Green = new PlotColor(0, 255, 0);
    public static readonly PlotColor Blue = new PlotColor(0, 0, 255);
    public static readonly PlotColor Black = new PlotColor(0, 0, 0);
    public static readonly PlotColor White = new PlotColor(255, 255, 255);

    public readonly string Color;

    public PlotColor(byte red, byte green, byte blue) {
      Color = "#" + red.ToString("X") + green.ToString("X") + blue.ToString("X");
    }

    public override string ToString() {
      return Color;
    }
  }
}