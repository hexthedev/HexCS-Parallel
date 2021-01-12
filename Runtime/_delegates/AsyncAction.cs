using System.Threading.Tasks;

namespace HexCS.Parallel
{
    /// <summary>
    /// Delegate describing an action that returns task.
    /// </summary>
    /// <returns></returns>
    public delegate Task AsyncAction();

    /// <summary>
    /// An async action that takes in an input
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="input"></param>
    /// <returns></returns>
    public delegate Task AsyncAction<T>(T input);
}
