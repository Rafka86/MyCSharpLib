using System;
using System.Collections.Generic;

namespace Librafka.MathLib {
  internal enum CharacterType { Num, Alp, Opr, Brc }

  internal enum StringType { Fnc, Cns, Var }

  internal static class Converter {
    private static readonly Stack<Token> Mem = new Stack<Token>();

    private static CharacterType GetCharType(char c) {
      if ('0' <= c && c <= '9') return CharacterType.Num;
      if ('A' <= c && c <= 'Z' || 'a' <= c && c <= 'z') return CharacterType.Alp;
      switch (c) {
        case '(': case ')': return CharacterType.Brc;
        case '+': case '-': case '*': case '/': case '^': case '%': return CharacterType.Opr;
        case '.': return CharacterType.Num;
        default: throw new ArgumentOutOfRangeException(nameof(c),"数式として使用できない文字です．");
      }
    }

    private static StringType GetStringType(string s) {
      switch (s) {
        case "SIN": case "COS": case "TAN": case "SINH": case "COSH": case"TANH": case "LOG": case "EXP": return StringType.Fnc;
        case "PI": case "E": case "EPS": return StringType.Cns;
        default: return StringType.Var;
      }
    }

    internal static Queue<Token> Tokenize(string s) {
      var expr = new Queue<Token>();

      expr.Clear();

      for (var i = 0; i < s.Length; i++) {
        int si;
        switch (GetCharType(s[i])) {
          case CharacterType.Num:
            si = i;
            while (i < s.Length && (GetCharType(s[i]) == CharacterType.Num || s[i] == '.')) i++;
            if (i < s.Length && GetCharType(s[i]) != CharacterType.Opr) s.Insert(i, "*");
            expr.Enqueue(new Token(TokenType.Num, s.Substring(si, i - si)));
            i--; break;
          case CharacterType.Alp:
            si = i;
            while (i < s.Length && (GetCharType(s[i]) == CharacterType.Num || GetCharType(s[i]) == CharacterType.Alp)) i++;
            if (i < s.Length && GetCharType(s[i]) != CharacterType.Opr) s.Insert(i, "*");
            var buf = s.Substring(si, i - si);
            switch (GetStringType(buf.ToUpper())) {
              case StringType.Fnc: expr.Enqueue(new Token(TokenType.Fnc, buf)); break;
              case StringType.Cns: expr.Enqueue(new Token(TokenType.Cns, buf)); break;
              case StringType.Var: break;
              default: expr.Enqueue(new Token(TokenType.Var, buf)); break;
            }
            i--; break;
          case CharacterType.Opr:
            if ((i == 0 || s[i - 1] == '(') && s[i] == '-') expr.Enqueue(new Token(TokenType.Opr, "_"));
            else expr.Enqueue(new Token(TokenType.Opr, s.Substring(i, 1)));
            break;
          case CharacterType.Brc: expr.Enqueue(new Token(TokenType.Brc, s.Substring(i, 1))); break;
          default: throw new ArgumentOutOfRangeException();
        }
      }

      return expr;
    }

    internal static void ToRpn(Queue<Token> expr) {
      var n = expr.Count;

      Mem.Clear();

      for (var i = 0; i < n; i++) {
        var t = expr.Dequeue();
        switch (t.Identity) {
          case TokenType.Num:	case TokenType.Cns:	case TokenType.Var:	expr.Enqueue(t); break;
          case TokenType.Fnc:	Mem.Push(t); break;
          case TokenType.Brc:
            if (t.Buffer == "(") Mem.Push(t);
            if (t.Buffer == ")") {
              while (Mem.Peek().Buffer != "(") expr.Enqueue(Mem.Pop());
              Mem.Pop();
              if (Mem.Count != 0 && Mem.Peek().Identity == TokenType.Fnc) expr.Enqueue(Mem.Pop());
            } break;
          case TokenType.Opr:
            if (Mem.Count == 0) { Mem.Push(t); break; }
            while (Mem.Count != 0 && Mem.Peek().Identity == TokenType.Opr) 
              if ((t.LeftCat && t.Priority >= Mem.Peek().Priority) || t.Priority > Mem.Peek().Priority) expr.Enqueue(Mem.Pop());
              else break;
            Mem.Push(t); break;
          default: throw new ArgumentOutOfRangeException();
        }
      }
      while (Mem.Count != 0) expr.Enqueue(Mem.Pop());
    }
  }
}