namespace csharp
{
    public class UpdateFactory
    {
        public static IUpdate Create(Item item)
        {
            if (item.Name.Contains("Aged Brie"))
            {
                return new AgedBrieUpdate();
            }
            else if (item.Name.Contains("Sulfuras"))
            {
                return new SulfurasUpdate();
            }
            else if (item.Name.Contains("Backstage pass"))
            {
                return new BackstagePassesUpdate();
            }
            else if (item.Name.Contains("Conjured"))
            {
                return new ConjuredUpdate();
            }
            else
            {
                return new StandardUpdate();
            }
        }
    }
}