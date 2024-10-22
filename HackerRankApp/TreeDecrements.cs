namespace HackerRankApp
{
	/// <summary>
	/// https://www.hackerrank.com/test/284sdq7h7cd/questions/c5b5fsj7ps8
	/// https://www.hackerrank.com/candidates/9e2i1bika8j?b=eyJ1c2VybmFtZSI6InRhbmdqaWFxaW5nQGhvdG1haWwuY29tIiwicGFzc3dvcmQiOiI1NTMzOTYwNiIsImhpZGUiOnRydWUsImFjY29tbW9kYXRpb25zIjp7ImFkZGl0aW9uYWxfdGltZV9wZXJjZW50Ijo1MH19&utm_campaign=candidate-portal-v1&utm_content=ebrlfo5bpe4&utm_medium=email&utm_source=button_go_to_test&utm_term=reminder
	/// 
	/// Reduction Trees 
	/// https://www.cs.ucr.edu/~nael/217-f15/lectures/217-lec10.pdf
	/// </summary>
	public static class TreeDecrements
	{
		private class Node
		{
			public static readonly Node Empty = new() { Index = -1, Value = -1 };

			// index from 0
			public int Index { get; set; }

			public int Value { get; set; }

			public List<Node> Neighbours { get; set; } = [];

			public bool IsLeaf { get => Neighbours.Count <= 1; }

			public bool IsEmpty { get => Value == 0; }
		}

		private class NodePair
		{
			public static readonly NodePair Empty = new() { Distance = -1 };

			public Node Node1 { get; set; } = Node.Empty;

			public Node Node2 { get; set; } = Node.Empty;

			public int Distance { get; set; }
		}

		private class NodeSearchContext
		{
			public Node StartNode { get; init; } = Node.Empty;

			public NodeSearchContext? PreviousSearch { get; set; }

			public bool IsSearched(Node node)
			{
				if (node == StartNode) return true;

				if (PreviousSearch != null) return PreviousSearch.IsSearched(node);

				return false;
			}
		}

		private class NodeSearchResult
		{
			public int? Level { get; set; }

			public Node? Value { get; set; }

			public NodeSearchResult? Next { get; set; }

			public NodeSearchResult? GetEndResult()
			{
				if (Value != null) return this;

				if (Next != null) return Next.GetEndResult();

				return null;
			}
		}

		private class Tree
		{
			public Node this[int index] { get => Nodes[index]; }

			public Dictionary<int, Node> Nodes { get; set; } = [];

			public Dictionary<int, Node> Leaves { get; set; } = [];
		}

		public static int Run(List<int> val, int tNodes, List<int> tFrom, List<int> tTo)
		{
			// number of nodes of value=1 is even number
			var costs = new List<int>();

			var tree = CreateTree(val);

			ConnectNodes(tree, tFrom, tTo);

			// select pairs so that their sum of distances is minimum.

			while (true)
			{
				// optional: remove node1 with value=0
				_ = RemoveEmptyLeaves(tree);

				if (tree.Nodes.Count == 0) break;

				// select a node1, select the nearest. cost+=distance, remove 2 nodes
				var pair = RemoveNearestNonEmptyLeaves(tree);

				if (pair == NodePair.Empty)
				{
					break;
				}
				else
				{
					costs.Add(pair.Distance);
				}

				// continue if there are more nodes.
				if (tree.Nodes.Count == 0) break;
			}

			return costs.Sum();
		}

		private static void ConnectNodes(Tree tree, List<int> froms, List<int> tos)
		{
			// connect nodes
			for (int i = 0; i < froms.Count; i++)
			{
				var fromNode = tree[froms[i] - 1];
				var toNode = tree[tos[i] - 1];

				fromNode.Neighbours.Add(toNode);
				toNode.Neighbours.Add(fromNode);
			}

			// find out leaves
			foreach (var node in tree.Nodes)
			{
				if (node.Value.IsLeaf)
				{
					tree.Leaves.Add(node.Key, node.Value);
				}
			}
		}

		private static Node CreateNode(int index, int value) => new() { Index = index, Value = value % 2 };

		private static Tree CreateTree(List<int> val)
		{
			var tree = new Tree();

			var nodes = val.Select((e, i) => CreateNode(i, e));

			foreach (var node in nodes)
			{
				tree.Nodes.Add(node.Index, node);
			}

			return tree;
		}

		private static List<Node> RemoveEmptyLeaves(Tree tree)
		{
			var emptys = new List<Node>();

			foreach (var node in tree.Leaves)
			{
				if (node.Value.IsEmpty)
				{
					emptys.Add(node.Value);
				}
			}

			emptys.ForEach((i) => RemoveNode(tree, i));

			if (emptys.Count > 0)
			{
				emptys.AddRange(RemoveEmptyLeaves(tree));
			}

			return emptys;
		}

		/// <summary>
		/// Remove one non-empty node1 and its closes non-empty neighbour
		/// </summary>
		/// <param name="tree"></param>
		/// <returns></returns>
		private static NodePair RemoveNearestNonEmptyLeaves(Tree tree)
		{
			if (tree.Leaves.Count == 0) return NodePair.Empty;

			var node1 = tree.Leaves.First().Value;

			var context = new NodeSearchContext()
			{
				StartNode = node1,
			};

			// node1 is in level 0
			var result = SearchNearesNonEmptyLeaf(node1, 1, context);

			var endResult = result.GetEndResult();

			var node2 = endResult!.Value!;

			node1.Value = 0;
			node2.Value = 0;

			return new NodePair
			{
				Distance = endResult.Level!.Value,
				Node1 = node1,
				Node2 = node2
			};
		}

		private static void RemoveNode(Tree tree, Node node)
		{
			foreach (var neighbour in node.Neighbours)
			{
				neighbour.Neighbours.Remove(node);

				if (neighbour.IsLeaf)
				{
					tree.Leaves.TryAdd(neighbour.Index, neighbour);
				}
			}

			node.Neighbours.Clear();

			tree.Nodes.Remove(node.Index);
			tree.Leaves.Remove(node.Index);
		}

		private static NodeSearchResult SearchNearesNonEmptyLeaf(Node node, int level, NodeSearchContext context)
		{
			var neighbours = node.Neighbours
				.Where(i => !context.IsSearched(i))
				.ToList();

			foreach (var neighbour in node.Neighbours)
			{
				if (!neighbour.IsEmpty)
				{
					return new NodeSearchResult()
					{
						Value = neighbour,
						Level = level
				     	};
				}
			}

			if (level + 1 < context.Root.MaxLevel)
			{
				var subResults = new Dictionary<NodeSearchResult, int>();

				foreach (var neighbour in node.Neighbours)
				{
					if (neighbour == context.Previous) continue;

					var subContext = new NodeSearchContext(context.Root)
					{
						Previous = node
					};

					var subResult = SearchNearesNonEmptyLeaf(neighbour, level + 1, subContext);

					var subEndResult = subResult.GetEndResult();

					if (subEndResult != null)
					{
						if (subResult.Level < context.Root.MaxLevel)
						{
							context.Root.MaxLevel = subEndResult.Level!.Value;
						}

						subResults.Add(subResult, subEndResult.Level!.Value);
					}
				}

				if (subResults.Count > 0)
				{
					var selectedSubResult = subResults.FirstOrDefault(i => i.Value == context.Root.MaxLevel).Key;

					return new NodeSearchResult()
					{
						Next = selectedSubResult
					};
				}
			}

			return new NodeSearchResult();
		}
	}
}
