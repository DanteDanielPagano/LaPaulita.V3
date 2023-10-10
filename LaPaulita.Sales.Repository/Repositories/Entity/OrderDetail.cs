namespace LaPaulita.Sales.Repositories.Repositories.Entity
{
    public class OrderDetail : EntityCommon
    {
        public OrderHeader Order { get; set; }

        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public short ProductQuantity { get; set; }
    }
}
