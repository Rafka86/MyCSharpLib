using System;
using System.Numerics;

namespace Librafka.MathLib {
  /// <summary>
  /// 2×2行列のクラス．
  /// </summary>
  public class Matrix22 : Matrix {
    /// <inheritdoc />
    /// <summary>
    /// 2×2のサイズの0行列を作成する．
    /// </summary>
    public Matrix22() : base(2, 2) {
    }

    /// <inheritdoc />
    /// <summary>
    /// 要素数を割り当てて2×2行列を作成する．
    /// </summary>
    /// <param name="elements">割り当てる要素．</param>
    /// <exception cref="T:System.ArgumentException">要素数が4でない時に投げられる．</exception>
    public Matrix22(params double[] elements) : base(elements, 2, 2) {
      if (elements.Length != 4) throw new ArgumentException("要素数が合致していません．");
    }

    /// <inheritdoc />
    /// <summary>
    /// 要素数を割り当てて2×2行列を作成する．
    /// </summary>
    /// <param name="elements">割り当てる要素．</param>
    /// <exception cref="T:System.ArgumentException">2次元配列の形が適切でない時に投げられる．</exception>
    public Matrix22(double[,] elements) : base(elements) {
      if (elements.GetLength(0) != 2 || elements.GetLength(1) != 2) throw new ArgumentException("要素数が合致していません．");
    }
  }
}