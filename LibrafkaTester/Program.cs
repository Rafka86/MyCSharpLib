using static System.Console;

using Librafka.MathLib;

namespace LibrafkaTester {
  public class Program {
    public static void Main() {
      var exp = new Expression("sin(5*e^3)");
      WriteLine(exp.ToString());

      var v = new Vector(1.0, 1.0);
      var m = new Matrix(1.0, 0.0, 0.0, 1.0);
      WriteLine(v);
      WriteLine(m);
    }
  }
}