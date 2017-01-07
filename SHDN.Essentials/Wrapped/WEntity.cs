using System;
using System.Windows.Forms;
using GTA;
using SHDN.Essentials.Callbacks;

namespace SHDN.Essentials.Wrapped
{
    /// <summary>
    /// Represents a wrapped <see cref="GTA.Entity"/> with updating functionality.
    /// </summary>
    public abstract class WEntity : WObject
    {
        /// <summary>
        /// Raised when the <see cref="WEntity"/> receives a <c>KeyDown</c> event while being near the <see cref="Player"/>.
        /// </summary>
        public event EventHandler<KeyEventArgs> NearbyKeyDown;

        /// <summary>
        /// Raised when the <see cref="WEntity"/> receives a <c>KeyUp</c> event while being near the <see cref="Player"/>.
        /// </summary>
        public event EventHandler<KeyEventArgs> NearbyKeyUp;

        /// <summary>
        /// Initializes a new instance of the <see cref="WEntity"/> class.
        /// </summary>
        /// <param name="callbackManager">The callback manager.</param>
        /// <param name="entity">The entity to wrap.</param>
        protected WEntity(CallbackManager callbackManager, Entity entity)
            : base(callbackManager)
        {
            Entity = entity;
            RaiseEvents = true;
        }

        /// <summary>
        /// Gets the wrapped entity of the <see cref="WEntity"/>.
        /// </summary>
        public Entity Entity { get; }

        /// <summary>
        /// Gets the handle of the <see cref="WEntity"/>.
        /// </summary>
        public int Handle => Entity.Handle;

        /// <summary>
        /// Gets or sets additional data associated with the <see cref="WEntity"/>.
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// Gets or sets the range at which the <see cref="WEntity"/> can be interacted with.
        /// </summary>
        public float ProximityRange { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="WEntity"/> should receive specific events.
        /// </summary>
        public bool RaiseEvents { get; set; }

        /// <summary>
        /// Determines whether the <see cref="WEntity"/> is near the <see cref="Player"/>.
        /// </summary>
        /// <returns></returns>
        public bool IsNearPlayer()
        {
            return Game.PlayerPed.Position.DistanceTo2D(Entity.Position) <= ProximityRange;
        }
        
        /// <summary>
        /// Raises the <c>KeyDown</c> event of the <see cref="WEntity"/>.
        /// </summary>
        /// <param name="sender">The sender of the call.</param>
        /// <param name="e">The associated event data.</param>
        internal void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (!IsNearPlayer())
                return;

            NearbyKeyDown?.Invoke(sender, e);
        }

        /// <summary>
        /// Raises the <c>KeyUp</c> event of the <see cref="WEntity"/>.
        /// </summary>
        /// <param name="sender">The sender of the call.</param>
        /// <param name="e">The associated event data.</param>
        internal void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (!IsNearPlayer())
                return;

            NearbyKeyUp?.Invoke(sender, e);
        }
    }
}
