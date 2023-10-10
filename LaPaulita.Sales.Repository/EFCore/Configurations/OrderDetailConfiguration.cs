namespace LaPaulita.Sales.Repositories.EFCore.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(d => new { d.Id, d.ProductId });
            builder.Property(d => d.Id)
                .UseIdentityColumn();
            builder.Property(d => d.ProductPrice)
                .HasPrecision(8, 2);
        }
    }
}
