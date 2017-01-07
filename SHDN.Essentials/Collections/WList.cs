using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SHDN.Essentials.Callbacks;
using SHDN.Essentials.Wrapped;

namespace SHDN.Essentials.Collections
{
    /// <summary>
    /// Represents a collection of wrapped objects.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    public class WList<TEntity> : List<TEntity>, IWrapped
        where TEntity : WObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WList{TEntity}" /> class.
        /// </summary>
        public WList()
        {
            CallbackManager = new CallbackManager();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WList{TEntity}"/> class with an empty collection.
        /// </summary>
        /// <param name="callbackManager">The callback manager.</param>
        public WList(CallbackManager callbackManager)
        {
            CallbackManager = callbackManager;
        }

        /// <summary>
        /// Gets the <see cref="Callbacks.CallbackManager"/> handling the callbacks of the <see cref="WList{TEntity}"/>.
        /// </summary>
        public CallbackManager CallbackManager { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="WList{TEntity}"/> should raise <c>Tick</c> events.
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Raises the <c>Tick</c> event of the <see cref="WList{TEntity}"/> members.
        /// </summary>
        /// <param name="sender">The sender of the call.</param>
        /// <param name="eventArgs">The associated event data.</param>
        public void OnTick(object sender, EventArgs eventArgs)
        {
            if (!Enabled)
                return;

            foreach (TEntity obj in this)
                obj.OnTick(sender, eventArgs);

            CallbackManager.OnTick(sender, eventArgs);
        }

        /// <summary>
        /// Raises the <c>KeyDown</c> event of the <see cref="WList{TEntity}"/> members.
        /// </summary>
        /// <param name="sender">The sender of the call.</param>
        /// <param name="keyEventArgs">The associated event data.</param>
        public void OnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            foreach (WEntity obj in this.Where(x => x is WEntity).Cast<WEntity>())
                obj.OnKeyDown(sender, keyEventArgs);
        }

        /// <summary>
        /// Raises the <c>KeyUp</c> event of the <see cref="WList{TEntity}"/> members.
        /// </summary>
        /// <param name="sender">The sender of the call.</param>
        /// <param name="keyEventArgs">The associated event data.</param>
        public void OnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            foreach (WEntity obj in this.Where(x => x is WEntity).Cast<WEntity>())
                obj.OnKeyUp(sender, keyEventArgs);
        }
    }
}
