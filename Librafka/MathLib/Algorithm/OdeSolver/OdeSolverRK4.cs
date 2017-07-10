using System.Collections.Generic;

namespace Librafka.MathLib.Algorithm {
  public static partial class OdeSolver {
    private const double Div6 = 1.0 / 6.0;
    
    /// <summary>
    /// 4次のルンゲクッタ法の1ステップを計算する．
    /// </summary>
    /// <param name="model">常微分方程式で記述される数理モデル．</param>
    /// <param name="time">時間</param>
    /// <param name="x">その時間での状態．</param>
    /// <returns>次の時間での状態．</returns>
    public static Vector Rk4Step(Ode model, double time, Vector x) {
      var k1 = model.Feval(time, x);
      var k2 = model.Feval(time + TimeStep * 0.5, x + k1 * TimeStep * 0.5);
      var k3 = model.Feval(time + TimeStep * 0.5, x + k2 * TimeStep * 0.5);
      var k4 = model.Feval(time + TimeStep, x + k3 * TimeStep);
      return x + (k1 + 2.0 * k2 + 2.0 * k3 + k4) * TimeStep * Div6;
    }

    /// <summary>
    /// 4次のルンゲクッタ法でシミュレーションを行う．
    /// </summary>
    /// <param name="model">常微分方程式で記述される数理モデル．</param>
    /// <returns>時系列に沿って格納された状態のリスト．</returns>
    public static List<Vector> Rk4Method(Ode model) {
      var x = model.InitialState.Clone;
      var t = model.StartTime;
      var res = new List<Vector> {new Vector(t).Concat(x)};
      while (t < model.EndTime) {
        var k1 = model.Feval(t, x);
        var k2 = model.Feval(t + TimeStep * 0.5, x + k1 * TimeStep * 0.5);
        var k3 = model.Feval(t + TimeStep * 0.5, x + k2 * TimeStep * 0.5);
        var k4 = model.Feval(t + TimeStep, x + k3 * TimeStep);
        x += (k1 + 2.0* k2 + 2.0 * k3 + k4) * TimeStep * Div6;
        t += TimeStep;
        res.Add(new Vector(t).Concat(x));
      }
      return res;
    }
  }
}