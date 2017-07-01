using System;
using System.Numerics;

using static System.Math;

namespace Librafka.MathLib {
  /// <summary>
  /// ベクトルの方向を示す列挙体．
  /// </summary>
  public enum VectorDirection {
    Column,
    Row
  }
  
  /// <summary>
  /// N次元複素ベクトルを表すクラス．
  /// </summary>
  public class Vector : Matrix {
    private readonly VectorDirection _direction;
    
    /// <summary>
    /// 要素数を指定してベクトルのインスタンスを作成する．
    /// 要素は全て複素数として0で向きは縦方向となる．
    /// </summary>
    /// <param name="size">ベクトルの要素数．</param>
    public Vector(int size) : base(size, 1) {
      _direction = VectorDirection.Column;
    }
    
    /// <summary>
    /// 要素と向きを指定してベクトルのインスタンスを作成する．
    /// </summary>
    /// <param name="elements">ベクトルの構成要素となる配列．</param>
    /// <param name="dir">ベクトルの向き．</param>
    public Vector(Complex[] elements, VectorDirection dir) : base(elements,
                                                                  dir == VectorDirection.Row ? 1 : elements.Length,
                                                                  dir == VectorDirection.Column ? 1 : elements.Length) {
      _direction = dir;
    }

    /// <summary>
    /// ベクトルのインデクサ．
    /// </summary>
    /// <param name="i">対象にしたい要素番号．</param>
    /// <exception cref="ArgumentOutOfRangeException">領域外参照時に投げられる．</exception>
    public Complex this[int i] {
      get {
        if (i < 0 || N <= i) throw new ArgumentOutOfRangeException(nameof(i));
        return E[i];
      }
      set {
        if (i < 0 || N <= i) throw new ArgumentOutOfRangeException(nameof(i));
        E[i] = value;
      }
    }
    
    public static Vector operator -(Vector v) {
      return -(v as Matrix) as Vector;
    }
    public static Vector operator +(Vector v1, Vector v2) {
      if (v1._direction != v2._direction) throw new ArgumentException("ベクトルの向きが異なります．");
      if (v1.N != v2.N) throw new ArgumentException("ベクトルの要素数が異なります．");
      return v1 as Matrix + v2 as Vector;
    }
    public static Vector operator -(Vector v1, Vector v2) {
      if (v1._direction != v2._direction) throw new ArgumentException("ベクトルの向きが異なります．");
      if (v1.N != v2.N) throw new ArgumentException("ベクトルの要素数が異なります．");
      return v1 as Matrix - v2 as Vector;
    }
    public static Vector operator *(Vector v, Complex k) {
      return (v as Matrix) * k as Vector;
    }
    public static Vector operator *(Complex k, Vector v) {
      return v * k;
    }
    public static dynamic operator *(Vector v1, Vector v2) {
      var res = (v1 as Matrix) * v2;
      if (v1._direction == VectorDirection.Row && v2._direction == VectorDirection.Column) return res[0, 0];
      return res;
    }
    public static Vector operator /(Vector v, Complex k) {
      return v as Matrix / k as Vector;
    }

    /// <summary>
    /// ベクトルのマンハッタン距離（1-ノルム）を取得する．
    /// </summary>
    public double ManhattanDistance {
      get {
        var res = 0.0;
        for (var i = 0; i < N; i++) res += E[i].Magnitude;
        return res;
      }
    }
    
    /// <summary>
    /// ベクトルのユークリッド距離（2-ノルム）を取得する．
    /// </summary>
    public double EuclidDistance {
      get {
        var res = 0.0;
        for (var i = 0; i < N; i++) res += E[i].Magnitude * E[i].Magnitude;
        return Sqrt(res);
      }
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
  }
}