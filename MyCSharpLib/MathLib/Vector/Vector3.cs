using System;
using System.Numerics;

namespace Librafka.MathLib {
  /// <summary>
  /// 3次元ベクトルのクラス．
  /// </summary>
  public class Vector3 : Vector {
    /// <summary>
    /// 全ての要素が0の3次元ベクトルを作成する．
    /// </summary>
    public Vector3() : base(3) {
    }

    /// <summary>
    /// 要素を与えて3次元ベクトルを作成する．
    /// </summary>
    /// <param name="elements">初期値．</param>
    /// <exception cref="ArgumentException">要素数が3を超えていると投げられる．</exception>
    public Vector3(params Complex[] elements) : base(elements) {
      if(elements.Length != 3) throw new ArgumentException("要素数が4ではありません．");
    }

    /// <summary>
    /// 3つの要素をそれぞれ与えて3次元ベクトルを作成する．
    /// </summary>
    /// <param name="x">第一要素．</param>
    /// <param name="y">第二要素．</param>
    /// <param name="z">第三要素．</param>
    public Vector3(Complex x, Complex y, Complex z) : base(x, y, z) {
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
    
    /// <summary>
    /// 第三要素に対するプロパティ．
    /// </summary>
    public Complex Z {
      get { return E[2]; }
      set { E[2] = value; }
    }
  }
}