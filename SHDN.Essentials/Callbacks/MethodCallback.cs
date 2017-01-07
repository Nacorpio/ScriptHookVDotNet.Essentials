using System;
using System.Reflection;

namespace SHDN.Essentials.Callbacks
{
    /// <summary>
    /// Represents a callback of which gets invoked when the method return value has changed.
    /// </summary>
    public sealed class MethodCallback : MemberCallback
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MethodCallback" /> class.
        /// </summary>
        /// <param name="instance">The instance to fetch the value from.</param>
        /// <param name="member">The method.</param>
        /// <param name="parameters">The parameters.</param>
        public MethodCallback(object instance, MethodInfo member, params object[] parameters) : base(instance, member)
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member));

            if (member.ReturnType == typeof(void))
                throw new ArgumentException("The method can't be void.", nameof(member));

            Parameters = parameters;
            Value = ((MethodInfo) Member).Invoke(instance, parameters);
        }

        /// <summary>
        /// Gets the parameters to invoke the <see cref="MethodCallback"/> with.
        /// </summary>
        public object[] Parameters { get; }

        /// <summary>
        /// Raises the <c>Tick</c> event of the <see cref="MemberCallback"/>.
        /// </summary>
        /// <param name="sender">The sender of the call.</param>
        /// <param name="e">The associated event data.</param>
        public override void OnTick(object sender, EventArgs e)
        {
            if (!Enabled)
                return;

            object newValue = ((MethodInfo) Member).Invoke(Instance, Parameters);
            if (newValue == Value) return;

            OnChanged(newValue, Value);
            Value = newValue;
        }
    }
}