namespace SHDN.Essentials.Storage
{
    /// <summary>
    /// Represents a stack of a specific <see cref="Storage.Item"/>.
    /// </summary>
    public sealed class ItemStack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        /// <param name="item">The stack type.</param>
        /// <param name="size">The stack size.</param>
        public ItemStack(Item item, int size)
        {
            Item = item;
            Size = size;
        }

        /// <summary>
        /// Gets the item type of the <see cref="ItemStack"/>.
        /// </summary>
        public Item Item { get; }

        /// <summary>
        /// Gets or sets the size of the <see cref="ItemStack"/>.
        /// </summary>
        public int Size { get; set; }
    }
}