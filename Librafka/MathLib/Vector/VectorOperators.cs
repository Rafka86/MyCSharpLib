using System;
using System.Numerics;

namespace Librafka.MathLib {  
  public partial class Vector {
    public static Vector operator -(Vector v) {
      for (var i = 0; i < v.N; i++) v[i] *= -1;
      return v;
    }
    
    public static Vector operator +(Vector v1, Vector v2) {
      if (v1.Direction != v2.Direction) throw new ArgumentException("ベクトルの向きが異なります．");
      if (v1.N != v2.N) throw new ArgumentException("ベクトルの要素数が異なります．");
      for (var i = 0; i < v1.N; i++) v1[i] += v2[i];
      return v1;
    }
    
    public static Vector operator -(Vector v1, Vector v2) {
      if (v1.Direction != v2.Direction) throw new ArgumentException("ベクトルの向きが異なります．");
      if (v1.N != v2.N) throw new ArgumentException("ベクトルの要素数が異なります．");
      for (var i = 0; i < v1.N; i++) v1[i] -= v2[i];
      return v1;
    }
    
    public static Vector operator *(Vector v, Complex k) {
      for (var i = 0; i < v.N; i++) v[i] *= k;
      return v;
    }
    
    public static Vector operator *(Complex k, Vector v) {
      return v * k;
    }
    
    public static dynamic operator *(Vector v1, Vector v2) {
      if (v1.Direction == v2.Direction) throw new ArgumentException("ベクトルの方向が同じです．");
      if (v1.N != v2.N) throw new ArgumentException("ベクトルの長さ異なります．");
      
      if (v1.Direction == VectorDirection.Row && v2.Direction == VectorDirection.Column) {
        var res = Complex.Zero;
        for (var i = 0; i < v1.N; i++) res += v1[i] * v2[i];
        return res;
      }
      else {
        var res = new Matrix(v1.N, v2.N);
        for (var i = 0; i < res.RowLength; i++)
          for (var j = 0; j < res.ColumnLength; j++)
            res[i, j] = v1[i] * v2[j];
        return res;
      }
    }

    public static Vector operator *(Vector v, Matrix m) {
      if (v.Direction != VectorDirection.Row || v.N != m.RowLength) throw new ArgumentException("積算できない形です．");

      var res = new Vector(m.ColumnLength);
      for (var i = 0; i < m.ColumnLength; i++) {
        var tmp = Complex.Zero;
        for (var j = 0; j < m.RowLength; j++) tmp += v[j] * m[j, i];
        res[i] = tmp;
      }
      return res;
    }

    public static Vector operator *(Matrix m, Vector v) {
      if (v.Direction != VectorDirection.Column || m.ColumnLength != v.N) throw new ArgumentException("積算できない形です．");

      var res = new Vector(m.RowLength);
      for (var i = 0; i < m.RowLength; i++) {
        var tmp = Complex.Zero;
        for (var j = 0; j < m.ColumnLength; j++) tmp +=  m[i, j] * v[j];
        res[i] = tmp;
      }
      return res;
    }
    
    public static Vector operator /(Vector v, Complex k) {
      for (var i = 0; i < v.N; i++) v[i] /= k;
      return v;
    }

    public static implicit operator Vector(Matrix m) {
      if (m.ColumnLength != 1 && m.RowLength != 1) throw new ArgumentException("指定された行列はベクトルに変換できません．");
      return new Vector(m.E) {Direction = m.ColumnLength == 1 ? VectorDirection.Column : VectorDirection.Row};
    }
  }
}