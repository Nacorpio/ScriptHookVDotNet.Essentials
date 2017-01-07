using System;
using GTA;
using SHDN.Essentials.Callbacks;

namespace SHDN.Essentials.Wrapped
{
    /// <summary>
    /// Represents a wrapped <see cref="GTA.Vehicle"/> with updating functionality.
    /// </summary>
    public class WVehicle : WEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WVehicle"/> class.
        /// </summary>
        /// <param name="callbackManager">The callback manager.</param>
        /// <param name="entity">The prop to wrap.</param>
        public WVehicle(CallbackManager callbackManager, Entity entity)
            : base(callbackManager, entity)
        {
            if (!(entity is Vehicle))
                throw new ArgumentException("The prop must be of type 'GTA.Vehicle'.", nameof(entity));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WVehicle"/> class.
        /// </summary>
        /// <param name="callbackManager">The callback manager.</param>
        /// <param name="vehicle">The vehicle to wrap.</param>
        public WVehicle(CallbackManager callbackManager, Vehicle vehicle)
            : this(callbackManager, (Entity) vehicle)
        { }

        /// <summary>
        /// Gets the wrapped <see cref="GTA.Vehicle"/> of the <see cref="WVehicle"/>.
        /// </summary>
        public Vehicle Vehicle => (Vehicle) Entity;
    }
}