using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SHDN.Essentials.Callbacks
{
    /// <summary>
    /// Represents a handler for <see cref="MemberCallback"/> objects.
    /// </summary>
    public sealed class CallbackManager : IWrapped
    {
        private readonly List<MemberCallback> _items;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CallbackManager" /> class.
        /// </summary>
        public CallbackManager()
        {
            _items = new List<MemberCallback>();
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="CallbackManager"/> should raise <c>Tick</c> events.
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Gets the items of the <see cref="CallbackManager"/>.
        /// </summary>
        public IReadOnlyList<MemberCallback> Items => _items;

        /// <summary>
        /// Subscribes to a <see cref="PropertyInfo"/> inside a specific instance.
        /// </summary>
        /// <param name="instance">The parent instance.</param>
        /// <param name="property">The property to subscribe to.</param>
        /// <param name="callback">The callback.</param>
        public void Subscribe(object instance, PropertyInfo property, CallbackEventHandler callback)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            if (IsSubscribed(property))
                return;

            var pcb = new PropertyCallback(instance, property);
            pcb.Changed += callback;

            _items.Add(pcb);
        }

        /// <summary>
        /// Subscribes to a <see cref="MethodInfo"/> inside a specific instance.
        /// </summary>
        /// <param name="instance">The parent instance.</param>
        /// <param name="method">The method to subscribe to.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="callback">The callback.</param>
        public void Subscribe(object instance, MethodInfo method, object[] parameters, CallbackEventHandler callback)
        {
            if (method == null)
                throw new ArgumentNullException(nameof(method));

            if (IsSubscribed(method))
                return;

            var mcb = new MethodCallback(instance, method, parameters);
            mcb.Changed += callback;

            _items.Add(mcb);
        }

        /// <summary>
        /// Unsubscribes from a <see cref="MemberInfo"/>.
        /// </summary>
        /// <param name="memberInfo">The member info to unsubscribe from.</param>
        public void Unsubscribe(MemberInfo memberInfo)
        {
            if (memberInfo == null)
                throw new ArgumentNullException(nameof(memberInfo));

            if (!IsSubscribed(memberInfo))
                return;

            _items.Remove(_items.Find(x => x.Member.Equals(memberInfo)));
        }

        /// <summary>
        /// Determines whether the <see cref="CallbackManager"/> is subscribed to a specific <see cref="MemberInfo"/>.
        /// </summary>
        /// <param name="memberInfo">The member info to check.</param>
        /// <returns></returns>
        public bool IsSubscribed(MemberInfo memberInfo)
        {
            return _items.Any(x => x.Member.Equals(memberInfo));
        }

        /// <summary>
        /// Raises the <c>Tick</c> event of the <see cref="CallbackManager"/>.
        /// </summary>
        /// <param name="sender">The sender of the call.</param>
        /// <param name="e">The associated event data.</param>
        public void OnTick(object sender, EventArgs e)
        {
            if (!Enabled)
                return;

            foreach (var callback in Items)
                callback.OnTick(sender, e);
        }
    }
}
