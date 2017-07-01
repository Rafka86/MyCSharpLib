using System;
using System.Numerics;
using System.Text;
using System.Xml;

namespace Librafka.MathLib {
  /// <summary>
  /// 任意の形を取ることのできる複素行列のクラス．
  /// </summary>
  public class Matrix {
    internal readonly Complex[] E;

    /// <summary>
    /// 行の長さを取得する．
    /// </summary>
    public int RowLength { get; protected set; }

    /// <summary>
    /// 列の長さを取得する．
    /// </summary>
    public int ColumnLength { get; protected set; }

    /// <summary>
    /// 行列の要素数を取得する．
    /// </summary>
    public int N { get; protected set; }

    /// <summary>
    /// 行列の形状を指定して行列クラスのインスタンスを作成する．
    /// 要素は全て0で埋められる．
    /// </summary>
    /// <param name="r">行のサイズ．</param>
    /// <param name="c">列のサイズ．</param>
    public Matrix(int r, int c) {
      RowLength = r;
      ColumnLength = c;
      N = r * c;
      E = new Complex[N];
      for (var i = 0; i < E.Length; i++) E[i] = Complex.Zero;
    }

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
    public Matrix(Complex[] elements) {
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

    /// <summary>
    /// 行列を複製します．
    /// </summary>
    /// <value>要素や行の長さ，列の長さが全く同じな別のインスタンス．</value>
    public Matrix Clone => new Matrix(E, RowLength, ColumnLength);

    /// <summary>
    /// 行列のインデクサ．
    /// </summary>
    /// <param name="i">行番号．</param>
    /// <param name="j">列番号．</param>
    public Complex this[int i, int j] {
      get {
        if (0 <= i && i <= RowLength && 0 <= j && j <= ColumnLength) return E[i * ColumnLength + j];
        throw new ArgumentException("領域外参照です．");
      }
      set {
        if (0 <= i && i <= RowLength && 0 <= j && j <= ColumnLength) E[i * ColumnLength + j] = value;
        else throw new ArgumentException("領域外参照です．");
      }
    }

    public static Matrix operator -(Matrix m) {
      var res = m.Clone;
      for (var i = 0; i < res.RowLength; i++)
        for (var j = 0; j < res.ColumnLength; j++)
          res[i, j] = -m[i, j];
      return res;
    }
    public static Matrix operator +(Matrix m1, Matrix m2) {
      if (m1.RowLength != m2.RowLength || m1.ColumnLength != m2.ColumnLength) throw new ArgumentException("行列の形が異なっています．");
      var res = new Matrix(m1.RowLength, m1.ColumnLength);
      for (var i = 0; i < res.RowLength; i++) 
        for (var j = 0; j < res.ColumnLength; j++)
          res[i, j] = m1[i, j] + m2[i, j];
      return res;
    }
    public static Matrix operator -(Matrix m1, Matrix m2) {
      if (m1.RowLength != m2.RowLength || m1.ColumnLength != m2.ColumnLength) throw new ArgumentException("行列の形が異なっています．");
      var res = new Matrix(m1.RowLength, m1.ColumnLength);
      for (var i = 0; i < res.RowLength; i++)
        for (var j = 0; j < res.ColumnLength; j++)
          res[i, j] = m1[i, j] - m2[i, j];
      return res;
    }
    public static Matrix operator *(Complex k, Matrix m) {
      var res = m.Clone;
      for (var i = 0; i < res.RowLength; i++)
        for (var j = 0; j < res.ColumnLength; j++)
          res[i, j] = k * m[i, j];
      return res;
    }
    public static Matrix operator *(Matrix m, Complex k) {
      return k * m;
    }
    public static Matrix operator *(Matrix m1, Matrix m2) {
      if (m1.ColumnLength != m2.RowLength) throw new ArgumentException("計算対象の行列の形が不適切です．");
      var res = new Matrix(m1.RowLength, m2.ColumnLength);
      for (var i = 0; i < res.RowLength; i++)
        for (var k = 0; k < m1.ColumnLength; k++)
          for (var j = 0; j < res.ColumnLength; j++)
            res[i, j] += m1[i, k] * m2[k, j];
      return res;
    }
    public static Matrix operator /(Matrix m, Complex k) {
      var res = new Matrix(m.RowLength, m.ColumnLength);
      for (var i = 0; i < m.RowLength; i++)
        for (var j = 0; j < m.ColumnLength; j++)
          res[i, j] = m[i, j] / k;
      return res;
    }

    /// <summary>
    /// 行列の要素を列挙する文字列を生成する．
    /// 書式を指定することができる．
    /// </summary>
    /// <returns>行列を表す文字列．</returns>
    /// <param name="format">各要素のフォーマット．</param>
    public string ToString(string format) {
      var sb = new StringBuilder();
      sb.Clear();

      for (var i = 0; i < RowLength; sb.Append(++i < RowLength ? "\n" : "")) 
        for (var j = 0; j < ColumnLength; sb.Append(++j < ColumnLength ? "\t" : "")) 
          sb.Append(this[i, j].ToString(format, null));
      
      return sb.ToString();
    }

    /// <summary>
    /// 行列の要素を列挙する文字列を生成する．
    /// 標準の書式指定文字列"G"を使用する．
    /// </summary>
    /// <returns>行列を表す文字列．</returns>
    public override string ToString() {
      return ToString("G");
    }

    /// <summary>
    /// インスタンスの転置行列を取得する．
    /// </summary>
    /// <value>転置後の行列の新しいインスタンス．</value>
    public Matrix Transpose {
      get {
        var res = new Matrix(ColumnLength, RowLength);
        for (var i = 0; i < RowLength; i++)
          for (var j = 0; j < ColumnLength; j++)
            res[j, i] = this[i, j];
        return res;
      }
    }

    /// <summary>
    /// インスタンスの共役転置行列を取得する．
    /// </summary>
    /// <value>The hermitian.</value>
    public Matrix Transjugate {
      get {
        // Analysis disable once NotResolvedInText
        if (IsEmpty()) throw new ArgumentNullException(nameof(Matrix), "行列素がありません．");
        var res = new Matrix(ColumnLength, RowLength);
        for (var i = 0; i < RowLength; i++)
          for (var j = 0; j < ColumnLength; j++) {
            var elem = E[i * ColumnLength + j];
            res[j, i] = new Complex(elem.Real, -elem.Imaginary);
          }
        return res;
      }
    }

    /// <summary>
    /// 行列要素があるかどうかを調べる．
    /// </summary>
    /// <returns>行列が空かどうかを示す真理値．</returns>
    public bool IsEmpty() {
      return E == null;
    }

    /// <summary>
    /// 最大の絶対値の値．
    /// </summary>
    public double MaxAbsoluteValue {
      get {
        var res = double.NegativeInfinity;
        for (var i = 0; i < N; i++) if (E[i].Magnitude > res) res = E[i].Magnitude;
        return res;
      }
    }

    /// <summary>
    /// 最小の絶対値の値．
    /// </summary>
    public double MinAbsoluteValue {
      get {
        var res = double.PositiveInfinity;
        for (var i = 0; i < N; i++) if (E[i].Magnitude < res) res = E[i].Magnitude;
        return res;
      }
    }
    
    /// <summary>
    /// 行列の形を指定して零行列を生成する．
    /// </summary>
    /// <param name="rowLength">行の大きさ．</param>
    /// <param name="columnLength">列の大きさ．</param>
    public static Matrix Zero(int rowLength, int columnLength) {
      return new Matrix(rowLength, columnLength);
    }
  }
}