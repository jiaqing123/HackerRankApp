namespace HackerRankApp.InProgress
{
    /// <summary>
    /// https://www.hackerrank.com/test/284sdq7h7cd/questions/c5b5fsj7ps8
    /// https://www.hackerrank.com/candidates/9e2i1bika8j?b=eyJ1c2VybmFtZSI6InRhbmdqaWFxaW5nQGhvdG1haWwuY29tIiwicGFzc3dvcmQiOiI1NTMzOTYwNiIsImhpZGUiOnRydWUsImFjY29tbW9kYXRpb25zIjp7ImFkZGl0aW9uYWxfdGltZV9wZXJjZW50Ijo1MH19&utm_campaign=candidate-portal-v1&utm_content=ebrlfo5bpe4&utm_medium=email&utm_source=button_go_to_test&utm_term=reminder
    /// 
    /// Reduction Trees 
    /// https://www.cs.ucr.edu/~nael/217-f15/lectures/217-lec10.pdf
    /// 
    /// https://www.google.com/search?q=tree+decrements+hackerrank&sca_esv=c649270f8124ba4f&rlz=1C1GCCU_en&source=lnms&fbs=AEQNm0CrHVBV9axs7YmgJiq-TjYc7RgyMjmhctvLCnk5YpVfOzTk9UgrCkq1LL6wECoQ_WEBrLFi_ZDAfZnWwCCCdYw5TyDJh-6F1pWv9bn7LdKw10nr9BTS-QWfvkuA-ty45AYNJnbDNhyc7iGnkkUWE9r0u_p5fjDE70LqcwwSSGSB9SY9bXfOLLHMYcl5KpJAE1aJmImr_O66nxsuqWg2RwgC4u0Dyw&sa=X&ved=2ahUKEwih3ob67qGJAxXIrlYBHf_oDuEQ0pQJegQIBBAD&biw=2560&bih=1305&dpr=1&safe=active&ssui=on
    /// https://stackoverflow.com/questions/73922682/decrement-node-values-to-0-of-a-given-tree
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
            public int MaxLevel { get; set; } = int.MaxValue;

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
            public static readonly NodeSearchResult Empty = new();

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
            if (val.Count == 0 || val.Count != tNodes) return 0;

            // number of nodes of value=1 is even number
            var costs = new List<int>();

            var tree = CreateTree(val, tFrom, tTo);

            // select pairs so that their sum of distances is minimum.

            // optional: remove node1 with value=0
            _ = RemoveEmptyLeaves(tree);

            while (true)
            {
                if (tree.Nodes.Count == 0) break;

                // select a node1, select the nearest. cost+=distance, remove 2 nodes
                //var pair = RemoveNearestNonEmptyLeaves(tree);
                var pair = RemoveNonEmptyLeaves(tree);

                if (pair == NodePair.Empty) break;

                costs.Add(pair.Distance);

                // continue if there are more nodes.
                if (tree.Nodes.Count == 0) break;
            }

            return costs.Sum();
        }

        private static Node CreateNode(int index, int value) => new() { Index = index, Value = value % 2 };

        private static Tree CreateTree(List<int> val, List<int> froms, List<int> tos)
        {
            var tree = new Tree();

            var nodes = val.Select((e, i) => CreateNode(i, e));

            foreach (var node in nodes)
            {
                tree.Nodes.Add(node.Index, node);
            }

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

        private static List<Node> RemoveEmptyLeaves(Tree tree, Node node)
        {
            var removeds = new List<Node>();

            if (node.IsLeaf && node.IsEmpty)
            {
                var neighbours = node.Neighbours.ToList();

                RemoveNode(tree, node);

                removeds.Add(node);

                foreach (var neighbour in neighbours)
                {
                    removeds.AddRange(RemoveEmptyLeaves(tree, neighbour));
                }
            }

            return removeds;
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
            var result = SearchNearestNonEmptyNode(node1, 1, context);

            var endResult = result.GetEndResult();

            var node2 = endResult!.Value!;

            node1.Value = 0;
            node2.Value = 0;

            RemoveEmptyLeaves(tree, node1);
            RemoveEmptyLeaves(tree, node2);

            return new NodePair
            {
                Distance = endResult.Level!.Value,
                Node1 = node1,
                Node2 = node2
            };
        }

        /// <summary>
        /// 55. but still more
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        private static NodePair RemoveNonEmptyLeaves(Tree tree)
        {
            if (tree.Leaves.Count == 0) return NodePair.Empty;

            for (int distance = 1; ; distance++)
            {
                foreach (var leaf in tree.Leaves.Values)
                {
                    var context = new NodeSearchContext
                    {
                        MaxLevel = distance,
                        StartNode = leaf,
                    };

                    var result = SearchNonEmptyNode(leaf, 1, context);

                    if (result != NodeSearchResult.Empty)
                    {
                        var endResult = result.GetEndResult();

                        var node2 = endResult!.Value!;

                        leaf.Value = 0;
                        node2.Value = 0;

                        RemoveEmptyLeaves(tree, leaf);
                        RemoveEmptyLeaves(tree, node2);

                        return new NodePair
                        {
                            Distance = endResult.Level!.Value,
                            Node1 = leaf,
                            Node2 = node2
                        };
                    }
                }
            }
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

        private static NodeSearchResult SearchNearestNonEmptyNode(Node node, int level, NodeSearchContext context)
        {
            var neighbours = node.Neighbours
                .Where(i => !context.IsSearched(i))
                .ToList();

            var nonempty = SelectNonEmptyNeighbours(neighbours).FirstOrDefault();
            if (nonempty != null)
            {
                return new NodeSearchResult()
                {
                    Value = nonempty,
                    Level = level,
                };
            }

            var maxLevel = context.MaxLevel;
            var minLevelResult = default(NodeSearchResult);

            foreach (var neighbour in neighbours)
            {
                var neighbourContext = new NodeSearchContext()
                {
                    MaxLevel = maxLevel,
                    PreviousSearch = context,
                    StartNode = neighbour,
                };

                var neighbourResult = SearchNearestNonEmptyNode(neighbour, level + 1, neighbourContext);

                if (neighbourResult != NodeSearchResult.Empty)
                {
                    var neighbourEndResult = neighbourResult.GetEndResult();

                    if (neighbourEndResult!.Level < maxLevel)
                    {
                        maxLevel = neighbourEndResult.Level!.Value;
                    }

                    if (minLevelResult == null)
                    {
                        minLevelResult = neighbourResult;
                    }
                    else if (neighbourEndResult.Level < minLevelResult.Level)
                    {
                        minLevelResult = neighbourResult;
                    }

                    if (maxLevel == level + 1) break;
                }
            }

            if (minLevelResult != null)
            {
                return new NodeSearchResult()
                {
                    Next = minLevelResult
                };
            }

            return NodeSearchResult.Empty;
        }

        private static NodeSearchResult SearchNonEmptyNode(Node node, int level, NodeSearchContext context)
        {
            var neighbours = node.Neighbours
                .Where(i => !context.IsSearched(i))
                .ToList();

            if (level < context.MaxLevel)
            {
                foreach (var neighbour in neighbours)
                {
                    var neighbourContext = new NodeSearchContext()
                    {
                        MaxLevel = context.MaxLevel,
                        PreviousSearch = context,
                        StartNode = neighbour,
                    };

                    var neighbourResult = SearchNonEmptyNode(neighbour, level + 1, neighbourContext);

                    if (neighbourResult != NodeSearchResult.Empty) return new NodeSearchResult
                    {
                        Next = neighbourResult
                    };
                }
            }
            else if (level == context.MaxLevel)
            {
                var nonempty = SelectNonEmptyNeighbours(neighbours).FirstOrDefault();
                if (nonempty != null)
                {
                    return new NodeSearchResult()
                    {
                        Value = nonempty,
                        Level = level,
                    };
                }
            }

            return NodeSearchResult.Empty;
        }

        private static IEnumerable<Node> SelectNonEmptyNeighbours(List<Node> neighbours)
        {
            var nonemptyNeighbours = new List<Node>();

            foreach (var neighbour in neighbours)
            {
                if (!neighbour.IsEmpty)
                {
                    nonemptyNeighbours.Add(neighbour);

                    if (neighbour.IsLeaf)
                    {
                        yield return neighbour;
                    }
                }
            }

            foreach (var neighbour in nonemptyNeighbours)
            {
                yield return neighbour;
            }
        }
    }
}
