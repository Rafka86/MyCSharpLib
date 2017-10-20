using System;
using System.Numerics;

namespace Librafka.MathLib {
  public partial class Matrix {
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

    public static explicit operator Matrix(Vector v) {
      return new Matrix(v.E,
                        v.Direction == VectorDirection.Column ? v.N : 1,
                        v.Direction == VectorDirection.Column ? 1 : v.N);
    }
  }
}