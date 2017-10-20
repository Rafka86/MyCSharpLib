using System;

namespace Librafka.MathLib {
  /// <summary>
  /// 3×3行列のクラス．
  /// </summary>
  public class Matrix33 : Matrix {
    /// <inheritdoc />
    /// <summary>
    /// 3×3のサイズの0行列を作成する．
    /// </summary>
    public Matrix33() : base(3, 3) {
    }

    /// <inheritdoc />
    /// <summary>
    /// 要素数を割り当てて3×3行列を作成する．
    /// </summary>
    /// <param name="elements">割り当てる要素．</param>
    /// <exception cref="T:System.ArgumentException">要素数が9でない時に投げられる．</exception>
    public Matrix33(params double[] elements) : base(elements, 3, 3) {
      if (elements.Length != 9) throw new ArgumentException("要素数が合致していません．");
    }

    /// <inheritdoc />
    /// <summary>
    /// 要素数を割り当てて3×3行列を作成する．
    /// </summary>
    /// <param name="elements">割り当てる要素．</param>
    /// <exception cref="T:System.ArgumentException">2次元配列の形が適切でない時に投げられる．</exception>
    public Matrix33(double[,] elements) : base(elements) {
      if (elements.GetLength(0) != 3 || elements.GetLength(1) != 3) throw new ArgumentException("要素数が合致していません．");
    }
  }
}