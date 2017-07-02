using System;
using System.Numerics;

namespace Librafka.MathLib {
  public partial class Matrix {
    /// <summary>
    /// 与えられた配列から行列クラスのインスタンスを作成する．
    /// 形はなるべく正方行列になるように作られる．
    /// 正方行列が無理な場合は，行のサイズと列のサイズは以下のように決定される．
    /// <code>
    /// RowLength = (int)Math.Sqrt(elements.Length);
    /// ColumnLength = RowLength + 1;
    /// </code>
    /// 行列は左上から埋められ，埋まらなかった部分は0で埋められる．
    /// </summary>
    /// <param name="elements">行列を構成する要素の1次元配列．</param>
    public Matrix(params Complex[] elements) {
      if (elements == null) throw new ArgumentNullException(nameof(elements), "要素が必要です．");

      RowLength = (int)Math.Sqrt(elements.Length);
      ColumnLength = RowLength + ((RowLength * RowLength == elements.Length) ? 0 : 1);
      E = new Complex[RowLength * ColumnLength];
      for (var i = 0; i < elements.Length; i++) E[i] = elements[i];
      if (elements.Length < E.Length)
        for (var i = elements.Length; i < E.Length; i++)
          E[i] = Complex.Zero;
      N = RowLength * ColumnLength;
    }

    /// <summary>
    /// 与えられた配列から行列クラスを作成する．
    /// 行のサイズと列のサイズは以下のように決定される．
    /// <code>
    /// RowLength = elements.GetLength(0);
    /// ColumnLength = elements.GetLength(1);
    /// </code>
    /// </summary>
    /// <param name="elements">行列を構成する要素の2次元配列．</param>
    public Matrix(Complex[,] elements) {
      if (elements == null) throw new ArgumentNullException(nameof(elements), "要素が必要です．");

      RowLength = elements.GetLength(0);
      ColumnLength = elements.GetLength(1);
      E = new Complex[RowLength * ColumnLength];
      for (var i = 0; i < elements.GetLength(0); i++)
        for (var j = 0; j < elements.GetLength(1); j++)
          E[i * ColumnLength + j] = elements[i, j];
      N = RowLength * ColumnLength;
    }

    /// <summary>
    /// 行と列のサイズを指定して行列クラスを作成する．
    /// </summary>
    /// <code>
    /// a[] = {1, 2, 3, 4, 5, 6}    => Matrix(a, 2, 3) == {{1, 2, 3}, {4, 5, 6}}
    /// a[] = {1, 2, 3, 4, 5}       => Matrix(a, 2, 3) == {{1, 2, 3}, {4, 5, 0}}
    /// a[] = {1, 2, 3, 4, 5, 6, 7} => Matrix(a, 2, 3) == {{1, 2, 3}, {4, 5, 6}}
    /// </code>
    /// <param name="elements">行列の要素が格納されている一次元配列．</param>
    /// <param name="row">行のサイズ．</param>
    /// <param name="column">列のサイズ．</param>
    public Matrix(Complex[] elements, int row, int column) {
      if (elements == null) throw new ArgumentNullException(nameof(elements), "要素が必要です．");

      RowLength = row;
      ColumnLength = column;
      E = new Complex[row * column];
      var n = E.Length < elements.Length ? E.Length : elements.Length;
      for (var i = 0; i < n; i++) E[i] = elements[i];
      if (E.Length > elements.Length)
        for (var i = elements.Length; i < E.Length; i++)
          E[i] = Complex.Zero;
      N = RowLength * ColumnLength;
    }
  }
}