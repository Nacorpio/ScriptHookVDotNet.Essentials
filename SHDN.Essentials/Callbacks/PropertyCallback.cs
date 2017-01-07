using System;
using System.Reflection;

namespace SHDN.Essentials.Callbacks
{
    /// <summary>
    /// Represents a callback of which gets invoked when the property value has changed.
    /// </summary>
    public sealed class PropertyCallback : MemberCallback
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:PropertyCallback" /> class.
        /// </summary>
        /// <param name="instance">The instance to fetch the value from.</param>
        /// <param name="member">The property.</param>
        public PropertyCallback(object instance, PropertyInfo member) : base(instance, member)
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member));

            Value = ((PropertyInfo) Member).GetValue(instance);
        }

        /// <summary>
        /// Raises the <c>Tick</c> event of the <see cref="PropertyCallback"/>.
        /// </summary>
        /// <param name="sender">The sender of the call.</param>
        /// <param name="e">The associated event data.</param>
        public override void OnTick(object sender, EventArgs e)
        {
            if (!Enabled)
                return;

            object newValue = ((PropertyInfo) Member).GetValue(Instance);
            if (newValue == Value) return;

            OnChanged(newValue, Value);
            Value = newValue;
        }
    }
}