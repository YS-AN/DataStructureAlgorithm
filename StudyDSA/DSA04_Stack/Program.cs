namespace DSA04_Stack
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//C#스택------------------ 
			UseStack useStack = new UseStack();
			useStack.TestStack();

			//stack 직접 정의---------
			UseNewDefStack();

			//stack 할용--------------
			PracticeStack();
		}

		static void UseNewDefStack()
		{
			DSA04_Stack.Stack<int> stack = new DSA04_Stack.Stack<int>();

			for (int i = 0; i < 8; ) 
				stack.Push(++i);

            Console.WriteLine($"PEEK : {stack.Peek()}"); //최상단  출력

			while (stack.Count > 0)
			{
				Console.Write($"{stack.Pop()} ");
				//output : 8 7 6 5 4 3 2 1 -> LIFO
			}
			Console.WriteLine("\n");
        }

		static void PracticeStack()
		{
			PracticeStack practice = new PracticeStack();

			//괄호검사
			Print_PracticeStack(practice, practiceType.ValidBracket, "()(){[안녕하세요!]}");
			Print_PracticeStack(practice, practiceType.ValidBracket, "()()");
			Print_PracticeStack(practice, practiceType.ValidBracket, "(({[]}))");
			Print_PracticeStack(practice, practiceType.ValidBracket, ")()(");
			Print_PracticeStack(practice, practiceType.ValidBracket, "안녕하세요");

			Console.WriteLine();

			//계산기
			Print_PracticeStack(practice, practiceType.Calculator, "7*3+5");
			Print_PracticeStack(practice, practiceType.Calculator, "5+7*3");
			Print_PracticeStack(practice, practiceType.Calculator, "4+(40/4+((1+4)+(3+4)))/(3*3-2)*2+(20+40*2)");

			Console.WriteLine();
		}

		static void Print_PracticeStack(PracticeStack practice, practiceType type, string message)
		{
			switch (type)
			{
				case practiceType.ValidBracket:
					Console.WriteLine($"[괄호검사] {message} >> {practice.IsValidBracket(message)}");
					break;
				case practiceType.Calculator:
					Console.WriteLine($"[계산] {message} = {practice.Calculator(message)}");
					break;
			}
		}

		public enum practiceType
		{
			ValidBracket,
			Calculator
		}
	}
}