using System;

namespace SHDN.Essentials.Storage
{
    /// <summary>
    /// Represents an <see cref="Item"/> of which can be used inside an inventory.
    /// </summary>
    public class ItemUsable : Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemUsable"/> class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        /// <param name="description">The description.</param>
        /// <param name="type">The item type.</param>
        /// <param name="rarity">The item rarity.</param>
        /// <param name="onUse">The function that gets invoked when using the item.</param>
        public ItemUsable(string displayName, string description, ItemType type, ItemRarity rarity, Action onUse) : base(displayName, description, type, rarity)
        {
            if (onUse == null)
                throw new ArgumentNullException(nameof(onUse));

            OnUse = onUse;
        }

        /// <summary>
        /// Gets or sets the method of which will be invoked when the <see cref="ItemUsable"/> is used from within an inventory.
        /// </summary>
        public Action OnUse { get; }
    }
}