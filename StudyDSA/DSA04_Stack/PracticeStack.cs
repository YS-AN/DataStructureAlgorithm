using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace DSA04_Stack
{
	internal class PracticeStack
	{
		/// <summary>
		/// 괄호 검사기
		/// </summary>
		/// <param name="str">검사할 문장</param>
		/// <returns></returns>
		public bool IsValidBracket(string str)
		{
			Dictionary<string, int> openBracket = new Dictionary<string, int>() { { "[", 0 }, { "{", 1 }, { "(", 2 }, { "<", 3 } };
			Dictionary<string, int> closeBracket = new Dictionary<string, int>() { { "]", 0 }, { "}", 1 }, { ")", 2 }, { ">", 3 } };

			var brackets = Regex.Matches(str, @"\[|\]|\{|\}|\(|\)|\<|\>");

			if (brackets.Count > 0)
			{
				Stack<string> stack = new Stack<string>();

				foreach (Match bracket in brackets)
				{
					if (openBracket.ContainsKey(bracket.Value))
					{
						stack.Push(bracket.Value);
					}
					else if (closeBracket.ContainsKey(bracket.Value))
					{
						if (stack.Count == 0)
							return false;

						if (openBracket[stack.Pop()] != closeBracket[bracket.Value])
						{
							return false;
						}
					}
				}
				return true;
			}
			return false;
		}

		/// <summary>
		/// 문자열 계산하기
		/// </summary>
		/// <param name="sentence"></param>
		/// <returns></returns>
		public int Calculator(string sentence)
		{
			if (IsCalcuate(sentence) == false)
				return ToInt(sentence);

			List<string> formulaCombo = new List<string>();

			//괄호를 기준으로 문자열을 분리함. 
			sentence = sentence.Replace("(", "_(");
			sentence = sentence.Replace(")", ")_");

			foreach (var item in sentence.Split("_"))
			{
				string formula = RemoveBracket(item); //계산을 위해 괄호 제거

				if (IsCalcuate(formula))
				{
					string calculatedPriority = CalcuatePriority(formula); //우선순위 연산자 계산
					int val = StackCalculator(calculatedPriority); //계산식 계산
					formulaCombo.Add(val.ToString()); //괄호안 계산 결과를 계산식에 다시 조합함
					continue;
				}
				formulaCombo.Add(item);
			}
			int result = Calculator(string.Join("", formulaCombo));
			return result;
		}

		/// <summary>
		/// 계산이 가능한 완벽한 계산식인가? (앞뒤가 기호가 아닌 숫자로 이뤄져있으면 완벽한 계산식이라고 판단함)
		/// </summary>
		/// <param name="sentence"></param>
		/// <returns></returns>
		private bool IsCalcuate(string sentence)
		{
			string clearStr = sentence.Replace(")", "");

			if (Regex.IsMatch(sentence, @"\+|\-|\*|\/"))
			{
				string chkStr = string.Format("{0}{1}", sentence[0], clearStr[clearStr.Length - 1]);
				int convertVal = 0;
				return int.TryParse(chkStr, out convertVal);
			}
			return false;
		}

		/// <summary>
		/// 계산식 앞뒤 괄호 제거
		/// </summary>
		/// <param name="sentence"></param>
		/// <returns></returns>
		private string RemoveBracket(string sentence)
		{
			int len = sentence.Length - 1;

			if (len > 0)
			{
				if (sentence[0] == '(' && sentence[len] == ')')
				{
					return sentence.Substring(1, (len - 1 > 0 ? len - 1 : 1));
				}
			}
			return sentence;
		}

		/// <summary>
		/// 우선순위 연산자 (/, *)만 먼저 계산
		/// </summary>
		/// <param name="sentence"></param>
		/// <returns></returns>
		private string CalcuatePriority(string sentence)
		{
			string pattern = @"\+|\-|\*|\/|\(|\)|[0-9]*";
			List<string> list = new List<string>();

			var matches = Regex.Matches(sentence, pattern);

			int index = 0;
			for (int i = 0; i < matches.Count; i++)
			{
				if (matches[i].Value == "/" || matches[i].Value == "*")
				{
					int num1 = ToInt(list[--index]);
					string sign = matches[i].Value;
					int num2 = ToInt(matches[++i].Value);

					list[index++] = DoCalculate(num2, num1, sign).ToString().Trim();
				}
				else
				{
					list.Add(matches[i].Value);
					index++;
				}
			}
			return $"({string.Join("", list)})";
		}

		/// <summary>
		/// 스택 활용하여 계산하기
		/// </summary>
		/// <param name="sentence">계산식</param>
		/// <returns></returns>
		public int StackCalculator(string sentence)
		{
			Stack<string> stack = new Stack<string>();

			string formula = string.Format(@"({0})", sentence);
			string pattern = @"\+|\-|\*|\/|\(|\)|[0-9]*";

			foreach (Match match in Regex.Matches(sentence, pattern))
			{
				if (match.Value.Trim() == "")
					continue;

				if (match.Value == ")")
				{
					DoCalculate(stack);
					continue;
				}
				stack.Push(match.Value);
			}
			return ToInt(stack.Pop());
		}

		/// <summary>
		/// 계산식 계산
		/// </summary>
		/// <param name="stack"></param>
		private void DoCalculate(Stack<string> stack)
		{
			int retVal = ToInt(stack.Pop());
			do
			{
				string sign = stack.Pop();
				int num = ToInt(stack.Pop());

				retVal = DoCalculate(retVal, num, sign);
			} while (stack.Peek() != "(");

			stack.Pop();
			stack.Push(retVal.ToString().Trim());
		}

		/// <summary>
		/// 계산식 계산
		/// </summary>
		/// <param name="num1"></param>
		/// <param name="num2"></param>
		/// <param name="sign"></param>
		/// <returns></returns>
		private int DoCalculate(int num1, int num2, string sign)
		{
			switch (sign)
			{
				case "+": return num2 + num1;
				case "-": return num2 - num1;
				case "*": return num2 * num1;
				case "/": return num2 / num1;
				default: return 0;
			}
		}

		/// <summary>
		/// 문자열 변환
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		private int ToInt(string str)
		{
			int val = 0;
			return int.TryParse(str, out val) ? val : 0;
		}

	}
}
