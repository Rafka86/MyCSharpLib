using System;
using static System.Math;

namespace Librafka.MathLib {
  public partial class Matrix {
    /// <summary>
    /// 行列のインデクサ．
    /// </summary>
    /// <param name="i">行番号．</param>
    /// <param name="j">列番号．</param>
    public double this[int i, int j] {
      get {
        if (0 <= i && i <= RowLength && 0 <= j && j <= ColumnLength) return E[i * ColumnLength + j];
        throw new ArgumentException("領域外参照です．");
      }
      set {
        if (0 <= i && i <= RowLength && 0 <= j && j <= ColumnLength) E[i * ColumnLength + j] = value;
        else throw new ArgumentException("領域外参照です．");
      }
    }

    /// <summary>
    /// 行列を複製します．
    /// </summary>
    /// <value>要素や行の長さ，列の長さが全く同じな別のインスタンス．</value>
    public Matrix Clone => new Matrix(E, RowLength, ColumnLength);
    
    /// <summary>
    /// インスタンスの転置行列を取得する．
    /// </summary>
    /// <value>転置後の行列の新しいインスタンス．</value>
    public Matrix Transpose {
      get {
        var res = new Matrix(ColumnLength, RowLength);
        for (var i = 0; i < RowLength; i++)
          for (var j = 0; j < ColumnLength; j++)
            res[j, i] = E[i * ColumnLength + j];
        return res;
      }
    }

    /// <summary>
    /// 最大の絶対値の値．
    /// </summary>
    public double MaxAbsoluteValue {
      get {
        var res = double.NegativeInfinity;
        for (var i = 0; i < N; i++) if (Abs(E[i]) > res) res = Abs(E[i]);
        return res;
      }
    }

    /// <summary>
    /// 最小の絶対値の値．
    /// </summary>
    public double MinAbsoluteValue {
      get {
        var res = double.PositiveInfinity;
        for (var i = 0; i < N; i++) if (Abs(E[i]) < res) res = Abs(E[i]);
        return res;
      }
    }
  }
}