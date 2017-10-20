namespace Librafka.MathLib {
  public partial class Matrix {
    /// <summary>
    /// 行列要素があるかどうかを調べる．
    /// </summary>
    /// <returns>行列が空かどうかを示す真理値．</returns>
    public bool IsEmpty() => E == null;

    /// <summary>
    /// 行列の形を指定して零行列を生成する．
    /// </summary>
    /// <param name="rowLength">行の大きさ．</param>
    /// <param name="columnLength">列の大きさ．</param>
    public static Matrix Zero(int rowLength, int columnLength) => new Matrix(rowLength, columnLength);
  }
}