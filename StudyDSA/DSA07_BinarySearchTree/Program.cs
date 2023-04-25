
using DSA07_BinarySearchTree.UserDefinition;

namespace DSA07_BinarySearchTree
{
	/// <summary>
	/// 이진트리 탐색
	/// </summary>
	internal class Program
	{
		static void Main(string[] args)
		{
			DoBinarySearchTree();

			Console.WriteLine("\n");

			CheckedTraversal();
		}

		static void DoBinarySearchTree()
		{
			BinarySearchTree<int> bst = new BinarySearchTree<int>();
			bst.Add(4);
			bst.Add(2);
			bst.Add(1);
			bst.Add(3);
			bst.Add(6);
			bst.Add(5);
			bst.Add(7);

			TreeTraversal treeTraversal = new TreeTraversal();
			treeTraversal.Print(bst.FindNode(4), TraversalType.Inorder);

			Console.WriteLine("\nDelete 5, 6");

			bst.Remove(6);
			bst.Remove(5);
			treeTraversal.Print(bst.FindNode(4), TraversalType.Inorder);
		}

		static void CheckedTraversal()
		{
			Node<string> root = new Node<string>("A", null);

			MakeNode(root, "B", "C");
			MakeNode(root.left, "D", "E");
			MakeNode(root.right, "F", "G");
			MakeNode(root.left.left, "H", "I");
			MakeNode(root.left.right, "J", "K");

			TreeTraversal treeTraversal = new TreeTraversal();

			Console.Write("전위 순회 : ");
			treeTraversal.Print(root, TraversalType.Preorder); //output. 전위 순회 : A   B   D   H   I   E   J   K   C   F   G

			Console.Write("\n\n중위 순회 : ");
			treeTraversal.Print(root, TraversalType.Inorder); //output. 중위 순회 : H   D   I   B   J   E   K   A   F   C   G

			Console.Write("\n\n후위 순회 : ");
			treeTraversal.Print(root, TraversalType.Postorder); //output. 후위 순회 : H   I   D   J   K   E   B   F   G   C   A
		}

		static void MakeNode (Node<string> parent, string left, string right)
		{
			parent.left = new Node<string>(left, parent);
			parent.right = new Node<string>(right, parent);
		}
	}
}