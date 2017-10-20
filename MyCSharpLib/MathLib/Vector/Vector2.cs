using System;
using System.Numerics;

namespace Librafka.MathLib {
  /// <summary>
  /// 2次元ベクトルのクラス．
  /// </summary>
  public class Vector2 : Vector {
    /// <summary>
    /// 全ての要素が0の2次元ベクトルを作成する．
    /// </summary>
    public Vector2() : base(2) {
    }

    /// <summary>
    /// 要素を与えて2次元ベクトルを作成する．
    /// </summary>
    /// <param name="elements">初期値．</param>
    /// <exception cref="ArgumentException">要素数が2を超えていると投げられる．</exception>
    public Vector2(params Complex[] elements) : base(elements) {
      if(elements.Length != 2) throw new ArgumentException("要素数が4ではありません．");
    }

    /// <summary>
    /// 2つの要素をそれぞれ与えて2次元ベクトルを作成する．
    /// </summary>
    /// <param name="x">第一要素．</param>
    /// <param name="y">第二要素．</param>
    public Vector2(Complex x, Complex y) : base(x, y) {
    }

    /// <summary>
    /// 第一要素に対するプロパティ．
    /// </summary>
    public Complex X {
      get { return E[0]; }
      set { E[0] = value; }
    }
    
    /// <summary>
    /// 第二要素に対するプロパティ．
    /// </summary>
    public Complex Y {
      get { return E[1]; }
      set { E[1] = value; }
    }
  }
}