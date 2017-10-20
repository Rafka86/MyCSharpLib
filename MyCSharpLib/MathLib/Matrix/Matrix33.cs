using System;
using System.Numerics;

namespace Librafka.MathLib {
  /// <summary>
  /// 3×3行列のクラス．
  /// </summary>
  public class Matrix33 : Matrix {
    /// <summary>
    /// 3×3のサイズの0行列を作成する．
    /// </summary>
    public Matrix33() : base(3, 3) {
    }

    /// <summary>
    /// 要素数を割り当てて3×3行列を作成する．
    /// </summary>
    /// <param name="elements">割り当てる要素．</param>
    /// <exception cref="ArgumentException">要素数が9でない時に投げられる．</exception>
    public Matrix33(params Complex[] elements) : base(elements, 3, 3) {
      if (elements.Length != 9) throw new ArgumentException("要素数が合致していません．");
    }

    /// <summary>
    /// 要素数を割り当てて3×3行列を作成する．
    /// </summary>
    /// <param name="elements">割り当てる要素．</param>
    /// <exception cref="ArgumentException">2次元配列の形が適切でない時に投げられる．</exception>
    public Matrix33(Complex[,] elements) : base(elements) {
      if (elements.GetLength(0) != 3 || elements.GetLength(1) != 3) throw new ArgumentException("要素数が合致していません．");
    }
  }
}