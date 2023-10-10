namespace LaPaulita.Sales.Repositories.EFCore.Configurations
{
    public class OrderHeaderConfiguration : IEntityTypeConfiguration<OrderHeader>
    {
        public void Configure(EntityTypeBuilder<OrderHeader> builder)
        {
            builder.Property(o => o.ClientId)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(o => o.ShippingAddress)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(o => o.ShippingCity)
                .IsRequired();

            builder.Property(o => o.ShippingCountry)
                .IsRequired();

            builder.Property(o => o.ShippingZip)
                .HasMaxLength(4);
        }
    }
}
