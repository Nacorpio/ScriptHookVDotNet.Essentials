using System;
using GTA;

namespace SHDN.Essentials.Wrapped
{
    public sealed class WPedGroup : IWrapped
    {
        /// <summary>
        /// Raised when the member count of the <see cref="WPedGroup"/> has changed.
        /// </summary>
        public event EventHandler MemberCountChanged;

        private int _memberCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        /// <param name="pedGroup">The ped group to wrap.</param>
        public WPedGroup(PedGroup pedGroup)
        {
            PedGroup = pedGroup;
            Init();
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="WPedGroup"/> should raise <c>Tick</c> events.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets the wrapped ped group of the <see cref="WPedGroup"/>.
        /// </summary>
        public PedGroup PedGroup { get; }

        private void Init()
        {
            _memberCount = PedGroup.MemberCount;
        }

        /// <summary>
        /// Raises the <c>Tick</c> event of the <see cref="WPedGroup"/>.
        /// </summary>
        /// <param name="sender">The sender of the call.</param>
        /// <param name="e">The associated event data.</param>
        public void OnTick(object sender, EventArgs e)
        {
            if (!Enabled)
                return;

            int newValue = PedGroup.MemberCount;
            if (_memberCount != newValue)
            {
                MemberCountChanged?.Invoke(sender, e);
                _memberCount = newValue;
            }
        }
    }
}
