namespace Danske.Models
{
    /// <summary>
    /// Interface represents root node with it's value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRoot<T>
    {
        /// <summary>
        /// Root node object reference
        /// </summary>
        IChild<T> RootNode { get; }
    }
}