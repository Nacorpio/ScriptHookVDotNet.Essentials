using System;
using GTA;
using SHDN.Essentials.Callbacks;

namespace SHDN.Essentials.Wrapped
{
    /// <summary>
    /// Represents a wrapped <see cref="GTA.Ped"/> with updating functionality.
    /// </summary>
    public class WPed : WEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WPed"/> class.
        /// </summary>
        /// <param name="callbackManager">The callback manager.</param>
        /// <param name="entity">The entity to wrap.</param>
        public WPed(CallbackManager callbackManager, Entity entity)
            : base(callbackManager, entity)
        {
            if (!(entity is Ped))
                throw new ArgumentException("The entity must be of type 'GTA.Ped'.", nameof(entity));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WPed"/> class.
        /// </summary>
        /// <param name="callbackManager">The callback manager.</param>
        /// <param name="ped">The ped to wrap.</param>
        public WPed(CallbackManager callbackManager, Ped ped)
            : this(callbackManager, (Entity) ped)
        { }

        /// <summary>
        /// Gets the wrapped <see cref="GTA.Ped"/> of the <see cref="WPed"/>.
        /// </summary>
        public Ped Ped => (Ped) Entity;
    }
}