namespace Danske.Models
{
    /// <summary>
    /// Implementing IRoot interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Root<T> : IRoot<T>
    {
        /// <summary>
        /// Node of the root
        /// </summary>
        public IChild<T> RootNode { get; }

        /// <summary>
        /// Specifying root values
        /// </summary>
        /// <param name="rootNode"></param>
        public Root(IChild<T> rootNode)
        {
            RootNode = rootNode;
        }
    }
}