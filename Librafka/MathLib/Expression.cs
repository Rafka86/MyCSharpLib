using System;
using System.Text;
using System.Collections.Generic;

namespace Librafka.MathLib {
	/// <summary>
	/// 数式を表すクラスである．
	/// 文字列で表された数式を計算できる形に解釈し，
	/// 任意のタイミングで任意の回数計算を行うことができる．
	/// </summary>
	public class Expression {
		private Queue<Token> _expr;
		private string _stringExp;

		/// <summary>
		/// 数式クラスのコンストラクタ．
		/// 文字列で表された数式を計算できる形に解釈する．
		/// </summary>
		/// <param name="exp">数式を表す文字列．</param>
		public Expression(string exp) {
			_stringExp = exp;
			_expr = Converter.Tokenize(exp.Replace(" ", ""));
			Converter.ToRpn(_expr);
		}

		/// <summary>
		/// 数式を計算し，値を求める．
		/// </summary>
		/// <param name="vars">式に含まれる変数に代入するための値の情報．</param>
		/// <returns>計算によって求められた値．</returns>
		public double Eval(Dictionary<string, double> vars) {
			var ans = new Stack<double>();

			for (var i = 0; i < _expr.Count; i++) {
				var t = _expr.Dequeue();
				switch(t.Identity){
					case TokenType.Num: ans.Push(double.Parse(t.Buffer)); break;
					case TokenType.Var:
						if (vars?.ContainsKey(t.Buffer) ?? false) ans.Push(vars[t.Buffer]);
						else throw new ArgumentOutOfRangeException("vars", "計算に必要な変数の値の情報が不足しています．");
						break;
					case TokenType.Opr:
						var p = ans.Pop();
						switch (t.Buffer) {
							case "+": ans.Push(ans.Pop() + p); break;
							case "-": ans.Push(ans.Pop() - p); break;
							case "*": ans.Push(ans.Pop() * p); break;
							case "/": ans.Push(ans.Pop() / p); break;
							case "%": ans.Push(ans.Pop() % p); break;
							case "^": ans.Push(Math.Pow(ans.Pop(), p)); break;
							case "_": ans.Push(-p); break;
						} break;
					case TokenType.Cns:
						switch(t.Buffer.ToUpper()) {
							case "PI": ans.Push(Math.PI); break;
							case "E": ans.Push(Math.E); break;
							case "EPS": ans.Push(double.Epsilon); break;
						} break;
					case TokenType.Fnc:
						switch(t.Buffer) {
							case "sin": case "SIN": ans.Push(Math.Sin(ans.Pop())); break;
							case "cos": case "COS": ans.Push(Math.Cos(ans.Pop())); break;
							case "tan": case "TAN": ans.Push(Math.Tan(ans.Pop())); break;
							case "Sin": ans.Push(Math.Asin(ans.Pop())); break;
							case "Cos": ans.Push(Math.Acos(ans.Pop())); break;
							case "Tan": ans.Push(Math.Atan(ans.Pop())); break;
							case "sinh": case "Sinh": case "SINH": ans.Push(Math.Sinh(ans.Pop())); break;
							case "cosh": case "Cosh": case "COSH": ans.Push(Math.Cosh(ans.Pop())); break;
							case "tanh": case "Tanh": case "TANH": ans.Push(Math.Tanh(ans.Pop())); break;
							case "exp": case "Exp": case "EXP": ans.Push(Math.Exp(ans.Pop())); break;
							case "log": case "Log": case "LOG": ans.Push(Math.Log(ans.Pop())); break;
						} break;
					case TokenType.Brc: break;
					default:
						throw new ArgumentOutOfRangeException();
				}
				_expr.Enqueue(t);
			}

			return ans.Pop();
		}

		/// <summary>
		/// 変数を含んでいない数式の値を求める．
		/// </summary>
		public double Eval() {
			return Eval(null);
		}

		/// <summary>
		/// 数式を変更する．
		/// </summary>
		/// <param name="newExpression">変更したい数式を表す文字列．</param>
		public void Change(string newExpression) {
			_stringExp = newExpression;
			_expr = Converter.Tokenize(newExpression.Replace(" ", ""));
			Converter.ToRpn(_expr);
		}

		/// <summary>
		/// 数式をコンソールに表示する．
		/// </summary>
		public void Print() {
			Console.WriteLine(_stringExp);
		}

		/// <summary>
		/// 逆ポーランド記法で表された数式の文字列を生成する．
		/// </summary>
		/// <returns>逆ポーランド記法で表された数式の文字列．</returns>
		public override string ToString() {
			var sb = new StringBuilder();

			sb.Clear();
			for (var i = 0; i < _expr.Count; sb.Append(++i < _expr.Count ? " " : "")) {
				var t = _expr.Dequeue();
				sb.Append(t.Buffer + " ");
				_expr.Enqueue(t);
			}

			return sb.ToString().TrimEnd();
		}
	}
}