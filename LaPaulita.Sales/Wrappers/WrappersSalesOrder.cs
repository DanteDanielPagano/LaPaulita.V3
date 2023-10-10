namespace LaPaulita.Sales.BusinessRules.Wrappers
{
    public class WrappersSalesOrder : BaseWrappers
    {
        public int OrderId { get; set; }
        public List<ValidationErrorDto> Errors { get; set; }
    }
}
