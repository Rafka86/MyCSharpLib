using System.Text;

namespace Librafka.MathLib {
  /// <summary>
  /// N次元複素ベクトルを表すクラス．
  /// </summary>
  public partial class Vector {
    internal double[] E;
    internal VectorDirection Direction;
    
    /// <summary>
    /// ベクトルの要素数を取得する．
    /// </summary>
    public int N { get; }

    /// <summary>
    /// 要素数を指定して列ベクトルのインスタンスを作成する．
    /// 要素は全て0で初期化される．
    /// </summary>
    /// <param name="size">ベクトルの要素数．</param>
    public Vector(int size) {
      Direction = VectorDirection.Column;
      N = size;
      E = new double[size];
      for (var i = 0; i < size; i++) E[i] = 0.0;
    }
    
    /// <summary>
    /// ベクトルの要素を列挙する文字列を生成する．
    /// 書式を指定することができる．
    /// </summary>
    /// <returns>ベクトルを表す文字列．</returns>
    /// <param name="format">各要素のフォーマット．</param>
    public string ToString(string format) {
      var sb = new StringBuilder();
      sb.Clear();

      switch (Direction) {
        case VectorDirection.Row:
          for (var i = 0; i < N; sb.Append(++i < N ? "\t" : "")) sb.Append(E[i].ToString(format, null));
          break;
        case VectorDirection.Column:
          for (var i = 0; i < N; sb.Append(++i < N ? "\n" : "")) sb.Append(E[i].ToString(format, null));
          break;
      }
      
      return sb.ToString();
    }

    /// <summary>
    /// ベクトルの要素を列挙する文字列を生成する．
    /// 標準の書式指定文字列"G"を使用する．
    /// </summary>
    /// <returns>ベクトルを表す文字列．</returns>
    public override string ToString() {
      return ToString("G");
    }
  }
}