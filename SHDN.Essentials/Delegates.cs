namespace SHDN.Essentials
{
    /// <summary>
    /// Represents the method that will handle <see cref="WEntity"/> callbacks.
    /// </summary>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="newValue">The new value.</param>
    /// <param name="oldValue">The old value.</param>
    public delegate void WEntityCallbackEventHandler<in TValue>(TValue newValue, TValue oldValue);
}
