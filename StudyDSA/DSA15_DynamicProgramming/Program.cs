namespace DSA15_DynamicProgramming
{
	internal class Program
	{
		/// <summary>
		/// 동적 계획법 알고리즘
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			Fibonacci fibonacci = new Fibonacci();
			Console.WriteLine(fibonacci.DoFibonacci(10));
		}
	}
}