using System;
using System.Collections.Generic;
using GTA;
using SHDN.Essentials.Wrapped;

namespace SHDN.Essentials.Collections
{
    /// <summary>
    /// Represents a set of <see cref="Entity"/> handles.
    /// </summary>
    public sealed class EntitySet : HashSet<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntitySet" /> class.
        /// </summary>
        public EntitySet(int capacity = -1)
        {
            if (capacity < -1)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            Capacity = capacity;
        }

        /// <summary>
        /// Gets the capacity of the <see cref="EntitySet"/>, at which no more elements can be added.
        /// </summary>
        public int Capacity { get; }

        /// <summary>
        /// Gets a value indicating whether the <see cref="EntitySet"/> has reached its maximum capacity.
        /// </summary>
        public bool IsFull => Count == Capacity;

        /// <summary>
        /// Adds an <see cref="Entity"/> object to the <see cref="EntitySet"/>.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <exception cref="ArgumentNullException">If <see cref="item"/> is <c>null</c>.</exception>
        /// <returns><c>true</c> if the item was added; otherwise, <c>false</c>.</returns>
        public bool Add(Entity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return Capacity != -1 && Count + 1 <= Capacity && Add(item.Handle);
        }

        /// <summary>
        /// Adds a <see cref="WEntity"/> object to the <see cref="EntitySet"/>.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <exception cref="ArgumentNullException">If <see cref="item"/> is <c>null</c>.</exception>
        /// <returns><c>true</c> if the item was added; otherwise, <c>false</c>.</returns>
        public bool Add(WEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return Add(item.Entity);
        }

        /// <summary>
        /// Determines whether the <see cref="EntitySet"/> contains an <see cref="Entity"/> object.
        /// </summary>
        /// <param name="item">The item to find.</param>
        /// <exception cref="ArgumentNullException">If <see cref="item"/> is <c>null</c>.</exception>
        /// <returns><c>true</c> if the item was found; otherwise, <c>false</c>.</returns>
        public bool Contains(Entity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return Contains(item.Handle);
        }

        /// <summary>
        /// Determines whether the <see cref="EntitySet"/> contains a <see cref="WEntity"/> object.
        /// </summary>
        /// <param name="item">The item to find.</param>
        /// <exception cref="ArgumentNullException">If <see cref="item"/> is <c>null</c>.</exception>
        /// <returns><c>true</c> of the item was found; otherwise, <c>false</c>.</returns>
        public bool Contains(WEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return Contains(item.Entity);
        }

        /// <summary>
        /// Removes an <see cref="Entity"/> object from the <see cref="EntitySet"/>.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <exception cref="ArgumentNullException">If <see cref="item"/> is <c>null</c>.</exception>
        /// <returns><c>true</c> if the item was removed; otherwise, <c>false</c>.</returns>
        public bool Remove(Entity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return Remove(item.Handle);
        }

        /// <summary>
        /// Removes a <see cref="WEntity"/> object from the <see cref="EntitySet"/>.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <exception cref="ArgumentNullException">If <see cref="item"/> is <c>null</c>.</exception>
        /// <returns><c>true</c> if the item was removed; otherwise, <c>false</c>.</returns>
        public bool Remove(WEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return Remove(item.Entity);
        }
    }
}
