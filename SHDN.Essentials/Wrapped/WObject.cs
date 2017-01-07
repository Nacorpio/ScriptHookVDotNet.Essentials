using System;
using System.Collections.Generic;
using SHDN.Essentials.Callbacks;

namespace SHDN.Essentials.Wrapped
{
    /// <summary>
    /// Represents a wrapped object.
    /// </summary>
    public abstract class WObject : IWrapped
    {
        /// <summary>
        /// Raised on the first tick of the <see cref="WObject"/>.
        /// </summary>
        public event EventHandler Init;

        /// <summary>
        /// Raised on every update of the <see cref="WObject"/>.
        /// </summary>
        public event EventHandler Tick;

        private bool _isInitialized;

        /// <summary>
        /// Initializes a new instance of the <see cref="WObject" /> class.
        /// </summary>
        /// <param name="callbackManager">The callback manager.</param>
        protected WObject(CallbackManager callbackManager)
        {
            CallbackManager = callbackManager;
        }

        /// <summary>
        /// Gets the <see cref="CallbackManager"/> instance that handles the <see cref="WObject"/>.
        /// </summary>
        public CallbackManager CallbackManager { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="WObject"/> should raise <c>Tick</c> events.
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Subscribes to a property in the <see cref="WObject"/>.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="propertyName">The name of a property to subscribe to.</param>
        /// <param name="callback">The <c>OnChanged</c> callback.</param>
        public void Subscribe(object instance, string propertyName, CallbackEventHandler callback)
        {
            // If the given property doesn't exist, just return.
            if (instance.GetType().GetProperty(propertyName) == null)
                return;

            CallbackManager.Subscribe(instance, instance.GetType().GetProperty(propertyName), callback);
        }

        /// <summary>
        /// Subscribes to the specific <see cref="Dictionary{TKey,TValue}"/> of properties in the given instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="callbacks">The properties to subscribe to.</param>
        public void Subscribe(object instance, Dictionary<string, CallbackEventHandler> callbacks)
        {
            foreach (KeyValuePair<string, CallbackEventHandler> callback in callbacks)
                Subscribe(instance, callback.Key, callback.Value);
        }

        /// <summary>
        /// Raises the <c>Tick</c> event of the <see cref="WObject"/>.
        /// </summary>
        /// <param name="sender">The sender of the call.</param>
        /// <param name="e">The associated event data.</param>
        public void OnTick(object sender, EventArgs e)
        {
            if (!Enabled)
                return;

            Tick?.Invoke(sender, e);

            if (_isInitialized) return;

            Init?.Invoke(sender, e);
            _isInitialized = true;
        }
    }
}
