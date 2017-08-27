namespace Librafka.MathLib.Utility {
  public partial struct PlotStyle {
    /// <summary>
    /// 線の種類を指定するコンストラクタ．
    /// それ以外の要素はデフォルトの値が使用される．
    /// </summary>
    /// <param name="lt">線の種類．</param>
    public PlotStyle(LineType lt) : this(lt, PlotColor.Red, 1, PointType.Dot, 1) {
    }

    /// <summary>
    /// 線の色を指定するコンストラクタ．
    /// それ以外の要素はデフォルトの値が使用される．
    /// </summary>
    /// <param name="pc">線の色．</param>
    public PlotStyle(PlotColor pc) : this(LineType.Solid, pc, 1, PointType.Dot, 1) {
    }

    /// <summary>
    /// 点の種類を指定するコンストラクタ．
    /// それ以外の要素はデフォルトの値が使用される．
    /// </summary>
    /// <param name="pt">点の種類．</param>
    public PlotStyle(PointType pt) : this(LineType.Solid, PlotColor.Red, 1, pt, 1) {
    }

    /// <summary>
    /// 線の色と幅を指定するコンストラクタ．
    /// </summary>
    /// <param name="pc">線の色．</param>
    /// <param name="lw">線の幅．</param>
    public PlotStyle(PlotColor pc, uint lw) : this(LineType.Solid, pc, lw, PointType.Dot, 1) {
    }

    /// <summary>
    /// 線の種類と色を指定するコンストラクタ．
    /// </summary>
    public PlotStyle(LineType lt, PlotColor pc) : this(lt, pc, 1, PointType.Dot, 1) {
    }
    
    /// <summary>
    /// プロットのスタイルを完全指定するコンストラクタ．
    /// </summary>
    /// <param name="lt">線の種類．</param>
    /// <param name="pc">プロットの色．</param>
    /// <param name="lw">線の幅．</param>
    /// <param name="pt">点の種類．</param>
    /// <param name="ps">点の大きさ．</param>
    public PlotStyle(LineType lt, PlotColor pc, uint lw, PointType pt, uint ps) {
      LineType = lt;
      PlotColor = pc;
      LineWidth = lw;
      PointType = pt;
      PointSize = ps;
    }
  }
}