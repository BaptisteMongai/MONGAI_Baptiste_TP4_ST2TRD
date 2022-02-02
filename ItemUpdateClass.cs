namespace csharp
{
    class AgedBrieUpdate : IUpdate
    {
        public void Update(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }

            item.SellIn -= 1;

            if (item.SellIn < 0 && item.Quality < 50)
            {
                item.Quality += 1;
            }
        }
    }
    
    public class SulfurasUpdate: IUpdate
    {
        public void Update(Item item)
        {
            //Nothing
        }
    }
    
    class BackstagePassesUpdate : IUpdate
    {
        //Decomposition into three "if" blocks so as not to exceed 50.
        public void Update(Item item)
        {
            if (item.SellIn > 0 && item.Quality < 50)
            {
                item.Quality += 1;
            }

            if (item.SellIn < 11 && item.Quality < 50)
            {
                item.Quality += 1;
            }

            if (item.SellIn < 6 && item.Quality < 50)
            {
                item.Quality += 1;
            }

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
    }

    class StandardUpdate : IUpdate
    {
        public void Update(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
            
            item.SellIn -= 1;

            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }
    }
    
    class ConjuredUpdate : IUpdate
    {
        public void Update(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 2;
            }

            item.SellIn -= 1;

            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality -= 2;
            }
            
            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }
    }
}