using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA04_Stack
{
	public class UseStack
	{
		public void TestStack()
		{
			Stack<int> stack = new Stack<int>();

			for(int i=0; i<10; i++)
			{
				stack.Push(i); //스택에 값을 넣어 줌
			}
			
			Console.WriteLine(stack.Peek()); //최상단에 있는 값을 출력

			while (stack.Count > 0)
			{
				Console.WriteLine(stack.Pop()); //스택에 있는 값을 뺌
			}
		}
	}
}
