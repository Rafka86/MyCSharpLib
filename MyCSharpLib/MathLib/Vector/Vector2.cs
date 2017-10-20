using System;

namespace Librafka.MathLib {
  /// <summary>
  /// 2次元ベクトルのクラス．
  /// </summary>
  public class Vector2 : Vector {
    /// <inheritdoc />
    /// <summary>
    /// 全ての要素が0の2次元ベクトルを作成する．
    /// </summary>
    public Vector2() : base(2) {
    }

    /// <inheritdoc />
    /// <summary>
    /// 要素を与えて2次元ベクトルを作成する．
    /// </summary>
    /// <param name="elements">初期値．</param>
    /// <exception cref="T:System.ArgumentException">要素数が2を超えていると投げられる．</exception>
    public Vector2(params double[] elements) : base(elements) {
      if(elements.Length != 2) throw new ArgumentException("要素数が4ではありません．");
    }

    /// <inheritdoc />
    /// <summary>
    /// 2つの要素をそれぞれ与えて2次元ベクトルを作成する．
    /// </summary>
    /// <param name="x">第一要素．</param>
    /// <param name="y">第二要素．</param>
    public Vector2(double x, double y) : base(x, y) {
    }

    /// <summary>
    /// 第一要素に対するプロパティ．
    /// </summary>
    public double X {
      get => E[0];
      set => E[0] = value;
    }
    
    /// <summary>
    /// 第二要素に対するプロパティ．
    /// </summary>
    public double Y {
      get => E[1];
      set => E[1] = value;
    }
  }
}