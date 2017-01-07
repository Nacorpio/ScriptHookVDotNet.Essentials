using System;
using System.ComponentModel;
using GTA;

namespace SHDN.Essentials.Storage
{
    /// <summary>
    /// Represents an item of which can be stored and managed within inventories.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        /// <param name="description">The description.</param>
        /// <param name="type">The item type.</param>
        /// <param name="rarity">The item rarity.</param>
        internal Item(string displayName, string description, ItemType type, ItemRarity rarity)
        {
            if (string.IsNullOrWhiteSpace(displayName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(displayName));

            if (!Enum.IsDefined(typeof(ItemType), type))
                throw new InvalidEnumArgumentException(nameof(type), (int) type, typeof(ItemType));

            if (!Enum.IsDefined(typeof(ItemRarity), rarity))
                throw new InvalidEnumArgumentException(nameof(rarity), (int) rarity, typeof(ItemRarity));

            DisplayName = displayName;
            Description = description;
            Type = type;
            Rarity = rarity;
        }

        /// <summary>
        /// Gets the unique identifier of the <see cref="Item"/>.
        /// </summary>
        public int Id { get; internal set; }

        /// <summary>
        /// Gets or sets the display name of the <see cref="Item"/>, of which will be visible inside inventories and menus.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the description of the <see cref="Item"/>.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the type of the <see cref="Item"/>.
        /// </summary>
        public ItemType Type { get; }

        /// <summary>
        /// Gets the rarity of the <see cref="Item"/>.
        /// </summary>
        public ItemRarity Rarity { get; }

        /// <summary>
        /// Gets the localization name of the <see cref="Item"/>.
        /// </summary>
        public string LocalizationName => DisplayName.Replace(' ', '_').ToLower();

        /// <summary>
        /// Gets or sets the method of which will be invoked when the <see cref="Item"/> is dropped from within an inventory.
        /// </summary>
        public Action OnDrop { get; set; }
    }
}
