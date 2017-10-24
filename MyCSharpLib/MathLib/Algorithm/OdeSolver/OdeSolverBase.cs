namespace Librafka.MathLib.Algorithm {
  /// <summary>
  /// 微分方程式を解くクラス．
  /// </summary>
  public partial class OdeSolver {
    /// <summary>
    /// 数値計算を行う際の時間刻みを表す．
    /// </summary>
    public double TimeStep { get; set; } = 1e-3;
  }
}