namespace LaPaulita.Sales.Repositories.EFCore.Context
{
    public class LaPaulitaSalesContext : DbContext
    {
        public LaPaulitaSalesContext(DbContextOptions<LaPaulitaSalesContext> options)
            : base(options) { }

        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly());
        }
    }
}
