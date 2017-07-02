using System;
using System.Numerics;

namespace Librafka.MathLib {
  /// <summary>
  /// 4×4行列のクラス．
  /// </summary>
  public class Matrix44 : Matrix {
    /// <summary>
    /// 4×4のサイズの0行列を作成する．
    /// </summary>
    public Matrix44() : base(4, 4) {
    }

    /// <summary>
    /// 要素数を割り当てて4×4行列を作成する．
    /// </summary>
    /// <param name="elements">割り当てる要素．</param>
    /// <exception cref="ArgumentException">要素数が16でない時に投げられる．</exception>
    public Matrix44(params Complex[] elements) : base(elements, 4, 4) {
      if (elements.Length != 16) throw new ArgumentException("要素数が合致していません．");
    }
    
    /// <summary>
    /// 要素数を割り当てて4×4行列を作成する．
    /// </summary>
    /// <param name="elements">割り当てる要素．</param>
    /// <exception cref="ArgumentException">2次元配列の形が適切でない時に投げられる．</exception>
    public Matrix44(Complex[,] elements) : base(elements) {
      if (elements.GetLength(0) != 4 || elements.GetLength(1) != 4) throw new ArgumentException("要素数が合致していません．");
    }
  }
}