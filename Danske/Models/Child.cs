using System.Collections.Generic;
using System.Linq;

namespace Danske.Models
{
    /// <summary>
    /// A generic implementation of a value node
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Child<T> : IChild<T>
    {
        /// <summary>
        /// The value of the node
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// List of child nodes
        /// </summary>
        public IEnumerable<IChild<T>> ChildNodes { get; }

        /// <summary>
        /// Constructs and instance of the class with it's value and children nodes
        /// </summary>
        /// <param name="value"> Value of the node </param>
        /// <param name="children"> Node's children nodes </param>
        public Child(T value, IEnumerable<IChild<T>> children)
        {
            Value = value;
            ChildNodes = children;
        }

        /// <summary>
        /// Constructs an instance of the class with its value and child nodes.
        /// The child nodes are provided as an unlimited list of parameters to the constructor.
        /// </summary>
        /// <param name="value"> The value of the node </param>
        /// <param name="children"> Unlimited list of children nodes </param>
        public Child(T value, params IChild<T>[] children)
        {
            Value = value;
            ChildNodes = children;
        }

        /// <summary>
        /// Retrieves all children nodes
        /// </summary>
        /// <returns></returns>
        public IChild<T>[] GetChildNodes()
        {
            return ChildNodes.ToArray();
        }
    }
}