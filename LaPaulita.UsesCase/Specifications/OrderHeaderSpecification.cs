namespace LaPaulita.UserCase.Specifications
{
    public partial class OrderHeaderSpecification : ISpecification<OrderHeaderDto>
    {
        readonly List<ValidationErrorDto> validationErrors = new List<ValidationErrorDto>();
        readonly OrderHeaderDto entity;

        public OrderHeaderSpecification(OrderHeaderDto entity)
        {
            this.entity = entity;
        }

        public List<ValidationErrorDto> IsValid()
        {
            IsClientIdValid();
            IsAddressValid();
            IsCityValid();
            IsCountryValid();
            IsZipValid();

            return validationErrors;
        }

        private partial void IsClientIdValid();
        private partial void IsAddressValid();
        private partial void IsCityValid();
        private partial void IsCountryValid();
        private partial void IsZipValid();
    }
}
