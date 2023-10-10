using System.Text.RegularExpressions;

namespace LaPaulita.UserCase.Specifications
{
    public partial class OrderHeaderSpecification : ISpecification<OrderHeaderDto>
    {
        private partial void IsZipValid()
        {
            if (string.IsNullOrEmpty(entity.ShippingZip))
            {
                validationErrors.Add(new ValidationErrorDto
                {
                    PropertyName = "ShippingZip",
                    ErrorMessage = "El código postal de entrega es obligatorio."
                });
            }

            if (entity.ShippingZip.Length != 4)
            {
                validationErrors.Add(new ValidationErrorDto
                {
                    PropertyName = "ShippingZip",
                    ErrorMessage = "El código postal de entrega debe contener 4 caracteres."
                });
            }

            // Patrón de expresión regular para verificar si solo contiene números
            string pattern = @"^[0-9]+$";

            // Verificar si la entrada coincide con el patrón
            bool isMatch = Regex.IsMatch(entity.ShippingZip, pattern);

            if (!isMatch)
            {
                validationErrors.Add(new ValidationErrorDto
                {
                    PropertyName = "SippingZip",
                    ErrorMessage = "El código postal de entrega debe contener solo números."
                });
            }
        }
    }
}
