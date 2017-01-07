using System;
using System.Reflection;

namespace SHDN.Essentials.Callbacks
{
    /// <summary>
    /// Represents the method that handles <see cref="MemberCallback"/> events.
    /// </summary>
    /// <param name="obj">The parent object.</param>
    /// <param name="newValue">The new value.</param>
    /// <param name="oldValue">The old value.</param>
    public delegate void CallbackEventHandler(object obj, object newValue, object oldValue);

    /// <summary>
    /// Represents a callback for the change of a value inside a <see cref="MemberInfo"/>.
    /// </summary>
    public abstract class MemberCallback : IWrapped
    {
        /// <summary>
        /// Raised when the value of the <see cref="MemberCallback"/> has changed.
        /// </summary>
        public event CallbackEventHandler Changed;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        /// <param name="instance">The instance to fetch the value from.</param>
        /// <param name="member">The member.</param>
        protected MemberCallback(object instance, MemberInfo member)
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member));

            Instance = instance;
            Member = member;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="MemberCallback"/> should raise <c>Tick</c> events.
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Gets the member of the <see cref="MemberCallback"/>.
        /// </summary>
        public MemberInfo Member { get; }

        /// <summary>
        /// Gets the instance of which to fetch the new value from.
        /// </summary>
        public object Instance { get; }

        /// <summary>
        /// Gets the current value of the <see cref="MemberCallback"/>.
        /// </summary>
        public object Value { get; protected set; }

        /// <summary>
        /// Raises the <see cref="Changed"/> event in the <see cref="MemberCallback"/>.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        /// <param name="oldValue">The old value.</param>
        protected void OnChanged(object newValue, object oldValue)
        {
            Changed?.Invoke(Instance, newValue, oldValue);
        }

        /// <summary>
        /// Raises the <c>Tick</c> event of the <see cref="MemberCallback"/>.
        /// </summary>
        /// <param name="sender">The sender of the call.</param>
        /// <param name="e">The associated event data.</param>
        public abstract void OnTick(object sender, EventArgs e);
    }
}
