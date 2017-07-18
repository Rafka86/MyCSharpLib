namespace Librafka.MathLib.Utility {
  /// <summary>
  /// プロットスタイルを指定する構造体．
  /// Gnuplotのlinetypeに対応する．
  /// </summary>
  public partial struct PlotStyle {
    /// <summary>
    /// インスタンスの示す線の種類のプロパティ．
    /// </summary>
    public LineType LineType { get; set; }
    
    /// <summary>
    /// インスタンスの示す線の色のプロパティ．
    /// </summary>
    public PlotColor PlotColor { get; set; }
    
    /// <summary>
    /// インスタンスの示す線の幅のプロパティ．
    /// </summary>
    public uint LineWidth { get; set; }
    
    /// <summary>
    /// インスタンスの示す点の種類のプロパティ．
    /// </summary>
    public PointType PointType { get; set; }
    
    /// <summary>
    /// インスタンスの示す点の大きさのプロパティ．
    /// </summary>
    public uint PointSize { get; set; }
  }
}