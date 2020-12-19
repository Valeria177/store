namespace Store.Data
{
    public class OrderItemDTO
    {
        public int Id { get; set; }

        public int DetailId { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public OrderDTO Order { get; set; }
    }
    
}