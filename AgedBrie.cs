namespace csharpcore
{
    internal class AgedBrie : ItemBase
    {
        public AgedBrie(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            IncrementQuality();

            DecreaseSellIn();

            if (HasPassedSellBy())
            {
                IncrementQuality();
            }
        }
    }
}