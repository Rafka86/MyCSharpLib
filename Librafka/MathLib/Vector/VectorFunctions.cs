using System;
using System.Numerics;
using static System.Math;

namespace Librafka.MathLib {
  public partial class Vector {
    /// <summary>
    /// ベクトル要素があるかどうかを調べる．
    /// </summary>
    /// <returns>ベクトルが空かどうかを示す真理値．</returns>
    public bool IsEmpty() {
      return E == null;
    }
    
    /// <summary>
    /// p-ノルムを計算する．
    /// </summary>
    /// <param name="p">ノルムの次数．</param>
    /// <returns>p-ノルムの値．</returns>
    /// <exception cref="ArgumentOutOfRangeException">次数が0未満の場合に投げられる．</exception>
    public double Norm(double p) {
      if (p < 0) throw new ArgumentOutOfRangeException(nameof(p));
      
      switch ((int) p) {
        case 0: return N;
        case 1: return ManhattanDistance;
        case 2: return EuclidDistance;
      }
      if (double.IsPositiveInfinity(p)) return MaxAbsoluteValue;

      var res = 0.0;
      for (var i = 0; i < N; i++) res += Pow(E[i].Magnitude, p);
      return Pow(res, 1.0 / p);
    }

    /// <summary>
    /// インスタンスに別のインスタンスの要素を結合する．
    /// </summary>
    /// <param name="v">結合したいベクトル．</param>
    public Vector Concat(Vector v) {
      var newE = new Complex[N + v.N];
      for (var i = 0; i < N; i++) newE[i] = E[i];
      for (var i = 0; i < v.N; i++) newE[N + i] = v.E[i];
      E = newE;
      return this;
    }
  }
}