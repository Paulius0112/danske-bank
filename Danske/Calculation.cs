using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Danske.Models;

namespace Danske
{
    /// <summary>
    /// Method for calculating max path and returning the path
    /// </summary>
    public static class Calculation
    {
        /// <summary>
        /// Traverse the binary tree starting from the root node
        /// </summary>
        /// <param name="node"> Root node </param>
        /// <param name="isValid"> Validation purpose </param>
        /// <param name="path"> The final path </param>
        /// <returns> Maximum path cost </returns>
        public static int FindMaxPath(IRoot<int> node, Func<IChild<int>, IChild<int>, bool> isValid, out string path)
        {
            var pathAccumulator = new StringBuilder();
            var rootNode = node.RootNode;
            var maxPath = FindMaxPath(rootNode, isValid, out path);
            return maxPath;
        }

        /// <summary>
        /// Traverse the binary tree starting from parent
        /// </summary>
        /// <param name="node"> Parent node </param>
        /// <param name="isValid"> Validation purpose </param>
        /// <param name="path"> The final path of the parent </param>
        /// <returns> Parent's path </returns>
        private static int FindMaxPath(IChild<int> node, Func<IChild<int>, IChild<int>, bool> isValid, out string path)
        {
            var maxPaths = new List<Tuple<int, string>>();
            foreach (var child in node.ChildNodes)
            {
                var max = FindTreeMaxPath(node, child, isValid, out string childPath);
                Tuple<int, string> tuple = new Tuple<int, string>(max, childPath);
                maxPaths.Add(tuple);
            }

            var maxNode = maxPaths.OrderByDescending(e => e.Item1).FirstOrDefault();

            if (maxNode == null)
            {
                path = node.Value.ToString();
                return node.Value;
            }

            var maxSum = maxNode.Item1;
            path = $"{node.Value.ToString()}, {maxNode.Item2}";

            return node.Value + maxSum;
        }

        /// <summary>
        /// Traverses through parent's children
        /// </summary>
        /// <param name="node"> Parent node </param>
        /// <param name="child"> Child node </param>
        /// <param name="isValid"> Validation purpose </param>
        /// <param name="path"> Final path of the children </param>
        /// <returns> The path from the children </returns>
        private static int FindTreeMaxPath(IChild<int> node, IChild<int> child,Func<IChild<int>, IChild<int>, bool> isValid,
            out string path)
        {
            if (!isValid(node, child) || child == null)
            {
                path = string.Empty;
                return 0;
            }

            return FindMaxPath(child, isValid, out path);
        }
        
    }
}