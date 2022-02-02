using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            { 
                IUpdate updateQualitySellIn = UpdateFactory.Create(item);
                updateQualitySellIn.Update(item);
            }
        }

    }
}
