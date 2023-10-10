namespace LaPaulita.Sales.BusinessRules.Interface
{
    public interface ISpecification<T> where T : class
    {
        List<ValidationErrorDto> IsValid();
    }
}
