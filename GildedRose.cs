namespace csharpcore
{
    using System.Collections.Generic;
    using System.Linq;

    public class GildedRose
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

        private IList<Item> Items;

        private IList<IUpdateQuality> _items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;

            _items = Items
                .Select(item => ItemFactory(item))
                .ToList();
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                item.UpdateQuality();
            }
        }

        private IUpdateQuality ItemFactory(Item item) 
        {
            if(IsAgedBrie(item)) 
            {
                return new AgedBrie(item);
            }
            if(IsBackstagePass(item)) 
            {
                return new BackstagePass(item);
            }
            if(IsSulfuras(item)) 
            {
                return new Sulfuras(item);
            }
            return new ItemBase(item);
        }

        private static bool IsBackstagePass(Item item) => 
            item.Name == BackstagePass;

        private static bool IsAgedBrie(Item item) =>
            item.Name == AgedBrie;

        private static bool IsSulfuras(Item item) =>
            item.Name == Sulfuras;
    }
}
