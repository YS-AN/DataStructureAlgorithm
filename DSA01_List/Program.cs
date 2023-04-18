namespace DSA01_List
{
	internal class Program
	{
		static void Main(string[] args)
		{
			DynamicArray dynamicArray = new DynamicArray();
			dynamicArray.UseList();

			Console.WriteLine("\n");

			UtilizeList utilizeList = new UtilizeList();
			utilizeList.DoUtilizeList();
		}
	}
}