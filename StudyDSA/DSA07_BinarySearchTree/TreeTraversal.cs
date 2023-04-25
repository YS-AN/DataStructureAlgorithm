using DSA07_BinarySearchTree.UserDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA07_BinarySearchTree
{
	/// <summary>
	/// 트리 순회
	/// </summary>
	internal class TreeTraversal
	{
		public void Print<T>(Node<T> node, TraversalType traversalType)
		{
			switch(traversalType)
			{
				case TraversalType.Preorder:
					PreorderTraversal(node);
					break;

				case TraversalType.Inorder:
					InorderTraversal(node);	
					break;

				case TraversalType.Postorder:
					PostorderTraversal(node);
					break;
			}
		}

		/// <summary>
		/// 전위 순회 
		/// </summary>
		private void PreorderTraversal<T>(Node<T> node)
		{
			if(node == null) { return; }

			Console.Write($"{node.item}   ");
			PreorderTraversal(node.left);
			PreorderTraversal(node.right);
		}

		/// <summary>
		/// 중위 순회
		/// </summary>
		private void InorderTraversal<T>(Node<T> node)
		{
			if (node == null) { return; }

			InorderTraversal(node.left);
			Console.Write($"{node.item}   ");
			InorderTraversal(node.right);
		}

		/// <summary>
		/// 후위 순회
		/// </summary>
		private void PostorderTraversal<T>(Node<T> node)
		{
			if (node == null) { return; }

			PostorderTraversal(node.left);
			PostorderTraversal(node.right);
			Console.Write($"{node.item}   ");
		}
	}

	public enum TraversalType
	{
		/// <summary>
		/// 전위 순회
		/// </summary>
		Preorder,

		/// <summary>
		/// 중위 순회
		/// </summary>
		Inorder,

		/// <summary>
		/// 후위 순회
		/// </summary>
		Postorder
	}
}
