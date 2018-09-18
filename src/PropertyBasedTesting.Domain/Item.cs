namespace PropertyBasedTesting.Domain
{
    public struct Item
    {
        public double Price { get; }

        // For the example, we are omitting other properties

        public Item(double price)
        {
            Price = price;
        }
    }
}