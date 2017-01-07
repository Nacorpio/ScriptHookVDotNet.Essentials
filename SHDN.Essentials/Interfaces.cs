using System;

namespace SHDN.Essentials
{
    public interface IWrapped
    {
        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="IWrapped"/> implementation should raise <c>Tick</c> events.
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// Raises the <c>Tick</c> event of the <see cref="IWrapped"/> implementation.
        /// </summary>
        /// <param name="sender">The sender of the call.</param>
        /// <param name="eventArgs">The associated event data.</param>
        void OnTick(object sender, EventArgs eventArgs);
    }
}