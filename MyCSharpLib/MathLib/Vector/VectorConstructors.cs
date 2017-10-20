using System;

namespace Librafka.MathLib {
  public partial class Vector {
    /// <summary>
    /// 可変長の要素から列ベクトルを生成する．
    /// </summary>
    /// <param name="elements">ベクトルの要素．</param>
    public Vector(params double[] elements) {
      Direction = VectorDirection.Column;
      N = elements.Length;
      E = new double[N];
      Array.Copy(elements, E, N);
    }

    /// <summary>
    /// 向きと要素を指定してベクトルのインスタンスを作成する．
    /// </summary>
    /// <param name="elements">ベクトルの要素．</param>
    /// <param name="dir">ベクトルの向き．</param>
    public Vector(VectorDirection dir, params double[] elements) {
      Direction = dir;
      N = elements.Length;
      Array.Copy(elements, E, N);
    }
  }
}