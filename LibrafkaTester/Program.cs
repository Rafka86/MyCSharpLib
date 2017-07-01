using static System.Console;

using Librafka.MathLib;

namespace LibrafkaTester {
  public class Program {
    public static void Main() {
      var exp = new Expression("sin(5*e^3)");
      WriteLine(exp.Eval());
      
      var v1 = new Vector(3);
      var v2 = new Vector(3);
      Vector v = v1 + v2;
    }
  }
}