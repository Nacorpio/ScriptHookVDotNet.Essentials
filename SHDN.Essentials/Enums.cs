namespace SHDN.Essentials
{
    /// <summary>
    /// Represents an <see cref="Storage.Item"/> type.
    /// </summary>
    public enum ItemType
    {
        Ingredient,
        Currency,
    }

    /// <summary>
    /// Represents an <see cref="Storage.Item"/> flag.
    /// </summary>
    public enum ItemFlag
    {
        Usable,
        Tradeable,
        Durable,
    }

    /// <summary>
    /// Represents an <see cref="Storage.Item"/> rarity.
    /// </summary>
    public enum ItemRarity
    {
        VeryCommon,
        Common,
        SemiCommon,
        Uncommon,
        SemiRare,
        Rare,
        VeryRare,
        ExtremelyRare
    }
}
