using System.Numerics;
using System.Text;

namespace Librafka.MathLib {
  /// <summary>
  /// 任意の形を取ることのできる複素行列のクラス．
  /// </summary>
  public partial class Matrix {
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
    /// 行列の要素を列挙する文字列を生成する．
    /// 書式を指定することができる．
    /// </summary>
    /// <returns>行列を表す文字列．</returns>
    /// <param name="format">各要素のフォーマット．</param>
    public string ToString(string format) {
      var sb = new StringBuilder();
      sb.Clear();

      for (var i = 0; i < RowLength; i++) 
        for (var j = 0; j < ColumnLength; sb.Append(++j < ColumnLength ? "\t" : "\n")) 
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
  }
}