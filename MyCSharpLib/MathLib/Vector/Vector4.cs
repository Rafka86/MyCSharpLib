using System;

namespace Librafka.MathLib {
  /// <summary>
  /// 4次元ベクトルのクラス．
  /// </summary>
  public class Vector4 : Vector {
    /// <inheritdoc />
    /// <summary>
    /// 全ての要素が0の4次元ベクトルを作成する．
    /// </summary>
    public Vector4() : base(4) {
    }

    /// <inheritdoc />
    /// <summary>
    /// 要素を与えて4次元ベクトルを作成する．
    /// </summary>
    /// <param name="elements">初期値．</param>
    /// <exception cref="T:System.ArgumentException">要素数が4を超えていると投げられる．</exception>
    public Vector4(params double[] elements) : base(elements) {
      if(elements.Length != 4) throw new ArgumentException("要素数が4ではありません．");
    }

    /// <inheritdoc />
    /// <summary>
    /// 4つの要素をそれぞれ与えて4次元ベクトルを作成する．
    /// </summary>
    /// <param name="x">第一要素．</param>
    /// <param name="y">第二要素．</param>
    /// <param name="z">第三要素．</param>
    /// <param name="w">第四要素．</param>
    public Vector4(double x, double y, double z, double w) : base(x, y, z, w) {
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
    
    /// <summary>
    /// 第三要素に対するプロパティ．
    /// </summary>
    public double Z {
      get => E[2];
      set => E[2] = value;
    }
    
    /// <summary>
    /// 第四要素に対するプロパティ．
    /// </summary>
    public double W {
      get => E[3];
      set => E[3] = value;
    }
  }
}