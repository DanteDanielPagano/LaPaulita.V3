namespace LaPaulita.UserCase.Specifications
{
    public partial class OrderHeaderSpecification : ISpecification<OrderHeaderDto>
    {
        private partial void IsAddressValid()
        {
            if (string.IsNullOrEmpty(entity.ShippingAddress))
            {
                validationErrors.Add(new ValidationErrorDto
                {
                    PropertyName = "ShippingAddress",
                    ErrorMessage = "La dirección de envío es requerida."
                });
            }

            if (entity.ShippingAddress.Length > 50)
            {
                validationErrors.Add(new ValidationErrorDto
                {
                    PropertyName = "ShippingAddres",
                    ErrorMessage = "La dirección de envío no puede exceder los 50 caracteres."
                });
            }
        }
    }
}
