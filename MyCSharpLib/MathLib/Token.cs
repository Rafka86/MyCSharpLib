namespace Librafka.MathLib {
  internal enum TokenType { Num, Var, Opr, Brc, Fnc, Cns }

  internal class Token {
    internal TokenType Identity { get; }
    internal string Buffer { get; }
    internal int Priority { get; }
    internal bool LeftCat { get; }

    private static int GetPriority(string s) {
      switch (s) {
        case "+": case "-":	return 2;
        case "*": case "/": case "%": case "_": return 1;
        case "^":	return 0;
        default: return int.MaxValue;
      }
    }

    private static bool IsLeftCat(string s) {
      return s != "^" && s != "_";
    }

    internal Token(TokenType type, string buf) {
      Identity = type;
      Buffer = buf;
      Priority = GetPriority(buf);
      LeftCat = IsLeftCat(buf);
    }
  }
}