namespace LaPaulita.UserCase.Specifications
{
    public partial class OrderHeaderSpecification : ISpecification<OrderHeaderDto>
    {
        private partial void IsCountryValid()
        {
            if (entity.ShippingCountry <= 0)
            {
                validationErrors.Add(new ValidationErrorDto
                {
                    PropertyName = "SippingCountry",
                    ErrorMessage = "El país de entrega es obligatorio."
                });
            }
        }
    }
}
