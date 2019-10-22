namespace csharpcore
{
    using System.Linq;

    internal class ItemBase : IUpdateQuality
    {
        protected Item item;

        public ItemBase(Item item)
        {
            this.item = item;
        }

        public virtual void UpdateQuality()
        {
            if (HasQualityValue())
            {
                DecreaseQuality();
            }

            DecreaseSellIn();

            if (HasPassedSellBy())
            {
                DecreaseQuality();
            }
        }

        protected bool HasQualityValue() =>
            item.Quality > 0;

        protected void DecreaseQuality()
        {
            if (HasQualityValue())
            {
                item.Quality--;
            }
        }

        protected void DecreaseQualityBy(int decrement)
        {
            Enumerable.Range(0,decrement)
                .ToList()
                .ForEach(_ => DecreaseQuality());
        }

        protected void SetQualityToMinimum() =>
            item.Quality = 0;

        protected void IncrementQuality()
        {
            if (BelowMaximumQuality())
            {
                item.Quality++;
            }
        }

        protected void IncrementQualityBy(int increment)
        {
            Enumerable.Range(0, increment)
                .ToList()
                .ForEach(_ => IncrementQuality());
        }

        protected bool BelowMaximumQuality() =>
            item.Quality < 50;

        protected void DecreaseSellIn() =>
            item.SellIn--;

        protected bool HasPassedSellBy() =>
            item.SellIn < 0;
    }
}