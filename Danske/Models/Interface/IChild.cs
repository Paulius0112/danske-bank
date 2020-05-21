using System.Collections.Generic;

namespace Danske.Models
{
    /// <summary>
    /// Interface represents child node with value and its children
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IChild<T>
    {
        /// <summary>
        /// The value of the node
        /// </summary>
        T Value { get; }

        /// <summary>
        /// Stores the below stored child nodes
        /// </summary>
        IEnumerable<IChild<T>> ChildNodes { get; }

        /// <summary>
        /// Returns the child nodes in array
        /// </summary>
        /// <returns></returns>
        IChild<T>[] GetChildNodes();
    }
}