namespace csharpcore
{
    internal class ConjuredManaCake : ItemBase
    {
        public ConjuredManaCake(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            if (HasQualityValue())
            {
                DecreaseQualityBy(2);
            }

            DecreaseSellIn();

            if (HasPassedSellBy())
            {
                DecreaseQualityBy(2);
            }
        }
    }
}