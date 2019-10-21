namespace csharpcore
{
    internal class BackstagePass : ItemBase
    {
        public BackstagePass(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            IncrementQualityBy(GetQualityIncrement());

            DecreaseSellIn();

            if (HasPassedSellBy())
            {
                SetQualityToMinimum();
            }
        }

        private int GetQualityIncrement()
        {
            if(item.SellIn < 6)
            {
                return 3;
            }

            if(item.SellIn < 11)
            {
                return 2;
            }
            
            return 1;
        }
    }
}