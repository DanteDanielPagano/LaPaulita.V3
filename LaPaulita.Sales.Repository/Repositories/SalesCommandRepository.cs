namespace LaPaulita.Sales.Repositories.Repositories
{
    public class SalesCommandRepository : ISalesCommandRepository
    {
        readonly LaPaulitaSalesContext _context;

        public SalesCommandRepository(LaPaulitaSalesContext context)
        {
            _context = context;
        }

        public async Task CreateOrder(CreateOrder order)
        {
            await _context.AddAsync(order);
            foreach (var item in order.Details)
            {
                await _context.AddAsync(new OrderDetail
                {
                    Order = order,
                    ProductId = item.ProductId,
                    ProductPrice = item.ProductPrice,
                    ProductQuantity = item.ProductQuantity
                });
            }
        }

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }
    }
}
