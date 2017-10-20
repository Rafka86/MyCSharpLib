using System.Collections.Generic;

namespace Librafka.MathLib.Algorithm {
  public static partial class OdeSolver {
    /// <summary>
    /// オイラー法の1ステップを計算する．
    /// </summary>
    /// <param name="model">常微分方程式で記述される数理モデル．</param>
    /// <param name="time">時間</param>
    /// <param name="x">その時間での状態．</param>
    /// <returns>次の時間での状態．</returns>
    public static Vector EulerStep(Ode model, double time, Vector x) {
      return x + model.Feval(time, x) * TimeStep;
    }

    /// <summary>
    /// オイラー法でシミュレーションを行う．
    /// </summary>
    /// <param name="model">常微分方程式で記述される数理モデル．</param>
    /// <returns>時系列に沿って格納された状態のリスト．</returns>
    public static List<Vector> EulerMethod(Ode model) {
      var x = model.InitialState.Clone;
      var t = model.StartTime;
      var res = new List<Vector> {new Vector(t).Concat(x)};
      while (t < model.EndTime) {
        x += model.Feval(t, x) * TimeStep;
        t += TimeStep;
        res.Add(new Vector(t).Concat(x));
      }
      return res;
    }
  }
}