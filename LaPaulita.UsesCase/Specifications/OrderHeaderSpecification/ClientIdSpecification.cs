namespace LaPaulita.UserCase.Specifications
{
    public partial class OrderHeaderSpecification : ISpecification<OrderHeaderDto>
    {
        private partial void IsClientIdValid()
        {
            if (entity.ClientId <= 0)
            {
                validationErrors.Add(new ValidationErrorDto
                {
                    PropertyName = "ClientId",
                    ErrorMessage = "El Id del cliente es obligatorio."
                });
            }
        }
    }
}
