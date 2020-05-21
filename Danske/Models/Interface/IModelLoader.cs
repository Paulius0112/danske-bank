namespace Danske.Models
{
    public interface IModelLoader<T>
    {
        /// <summary>
        /// Building binary tree nodes
        /// </summary>
        /// <returns></returns>
        IRoot<T> ConfigureRoot();
    }
}