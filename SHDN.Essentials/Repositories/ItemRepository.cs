using System;
using System.Collections.Generic;
using System.Linq;
using SHDN.Essentials.Storage;

namespace SHDN.Essentials.Repositories
{
    /// <summary>
    /// Represents a repository for registering <see cref="Storage.Item"/> objects.
    /// </summary>
    public static class ItemRepository
    {
        private static readonly Dictionary<int, Item> _items;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemRepository"/> class.
        /// </summary>
        static ItemRepository()
        {
            _items = new Dictionary<int, Item>();
        }

        /// <summary>
        /// Gets the registered items of the <see cref="ItemRepository"/>.
        /// </summary>
        public static IReadOnlyDictionary<int, Item> Items => _items;

        /// <summary>
        /// Registers an <see cref="Item"/> to the <see cref="ItemRepository"/>.
        /// </summary>
        /// <param name="item">The item to register.</param>
        public static void Register(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            int id = _items.Count;

            item.Id = id;
            _items.Add(id, item);
        }

        /// <summary>
        /// Determines whether the <see cref="ItemRepository"/> contains a specific <see cref="Item"/> object.
        /// </summary>
        /// <param name="item">The item to find.</param>
        /// <returns><c>true</c> if the item was found; otherwise, <c>false</c>.</returns>
        public static bool Contains(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return _items.Values.Any(x => x.Id.Equals(item.Id));
        }

        /// <summary>
        /// Returns a registered <see cref="Item"/> object with a specific localization name.
        /// </summary>
        /// <param name="localizationName">The localization name.</param>
        /// <returns></returns>
        public static Item Get(string localizationName)
        {
            return _items.Values.FirstOrDefault(x => x.LocalizationName.Equals(localizationName));
        }
    }
}
