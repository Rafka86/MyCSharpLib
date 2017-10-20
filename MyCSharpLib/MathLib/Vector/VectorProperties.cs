using System;

using static System.Math;

namespace Librafka.MathLib {
  public partial class Vector {
    /// <summary>
    /// ベクトルのインデクサ．
    /// </summary>
    /// <param name="i">対象にしたい要素番号．</param>
    /// <exception cref="ArgumentOutOfRangeException">領域外参照時に投げられる．</exception>
    public double this[int i] {
      get {
        if (i < 0 || N <= i) throw new ArgumentOutOfRangeException(nameof(i));
        return E[i];
      }
      set {
        if (i < 0 || N <= i) throw new ArgumentOutOfRangeException(nameof(i));
        E[i] = value;
      }
    }
    
    /// <summary>
    /// ベクトルを複製します．
    /// </summary>
    /// <value>要素と方向が複製された新たなインスタンス．</value>
    public Vector Clone => new Vector(Direction, E);
    
    /// <summary>
    /// 方向を変更したベクトルを作成する．
    /// </summary>
    /// <value>方向を変更した新しいインスタンス．</value>
    public Vector Transpose => new Vector(Direction == VectorDirection.Column ? VectorDirection.Row : VectorDirection.Column, E);

    /// <summary>
    /// 最大の絶対値の値．
    /// </summary>
    public double MaxAbsoluteValue {
      get {
        var res = double.NegativeInfinity;
        for (var i = 0; i < N; i++) if (Abs(E[i]) > res) res = Abs(E[i]);
        return res;
      }
    }

    /// <summary>
    /// 最小の絶対値の値．
    /// </summary>
    public double MinAbsoluteValue {
      get {
        var res = double.PositiveInfinity;
        for (var i = 0; i < N; i++) if (Abs(E[i]) < res) res = Abs(E[i]);
        return res;
      }
    }
    
    /// <summary>
    /// ベクトルのマンハッタン距離（1-ノルム）を取得する．
    /// </summary>
    public double ManhattanDistance {
      get {
        var res = 0.0;
        for (var i = 0; i < N; i++) res += Abs(E[i]);
        return res;
      }
    }
    
    /// <summary>
    /// ベクトルのユークリッド距離（2-ノルム）を取得する．
    /// </summary>
    public double EuclidDistance {
      get {
        var res = 0.0;
        for (var i = 0; i < N; i++) res += E[i] * E[i];
        return Sqrt(res);
      }
    }
  }
}