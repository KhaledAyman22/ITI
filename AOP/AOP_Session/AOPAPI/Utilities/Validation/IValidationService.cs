namespace AOPAPI.Utilities.Validation
{
    public interface IValidationService
    {
        bool IsValid<TInput>(TInput input) where TInput : class;
    }
}