namespace NorthbayWebAPI.ItemModels
{
    public class UpdateItem
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

    }
}
