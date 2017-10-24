using System.Collections.Generic;

namespace Librafka.MathLib.Algorithm {
  public partial class OdeSolver {
    /// <summary>
    /// 2次のルンゲクッタ法の1ステップを計算する．
    /// </summary>
    /// <param name="model">常微分方程式で記述される数理モデル．</param>
    /// <param name="time">時間</param>
    /// <param name="x">その時間での状態．</param>
    /// <returns>次の時間での状態．</returns>
    public Vector Rk2Step(Ode model, double time, Vector x) {
      var k1 = model.Feval(time, x);
      var k2 = model.Feval(time + TimeStep, x + k1 * TimeStep);
      return x + (k1 + k2) * 0.5 * TimeStep;
    }

    /// <summary>
    /// 2次のルンゲクッタ法でシミュレーションを行う．
    /// </summary>
    /// <param name="model">常微分方程式で記述される数理モデル．</param>
    /// <returns>時系列に沿って格納された状態のリスト．</returns>
    public List<Vector> Rk2Method(Ode model) {
      var x = model.InitialState.Clone;
      var t = model.StartTime;
      var res = new List<Vector> {new Vector(t).Concat(x)};
      while (t < model.EndTime) {
        var k1 = model.Feval(t, x);
        var k2 = model.Feval(t + TimeStep, x + k1 * TimeStep);
        x += (k1 + k2) * 0.5 * TimeStep;
        t += TimeStep;
        res.Add(new Vector(t).Concat(x));
      }
      return res;
    }
  }
}