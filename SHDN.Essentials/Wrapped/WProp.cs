using System;
using GTA;
using GTA.Math;
using SHDN.Essentials.Callbacks;

namespace SHDN.Essentials.Wrapped
{
    /// <summary>
    /// Represents a wrapped <see cref="GTA.Prop"/> with updating functionality.
    /// </summary>
    public class WProp : WEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WProp"/> class.
        /// </summary>
        /// <param name="callbackManager">The callback manager.</param>
        /// <param name="entity">The prop to wrap.</param>
        public WProp(CallbackManager callbackManager, Entity entity)
            : base(callbackManager, entity)
        {
            if (!(entity is Prop))
                throw new ArgumentException("The prop must be of type 'GTA.Prop'.", nameof(entity));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WProp"/> class.
        /// </summary>
        /// <param name="callbackManager">The callback manager.</param>
        /// <param name="prop">The prop to wrap.</param>
        public WProp(CallbackManager callbackManager, Prop prop)
            : this(callbackManager, (Entity) prop)
        { }

        /// <summary>
        /// Gets the wrapped <see cref="GTA.Prop"/> of the <see cref="WProp"/>.
        /// </summary>
        public Prop Prop => (Prop) Entity;
    }
}