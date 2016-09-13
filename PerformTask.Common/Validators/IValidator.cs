namespace PerformTask.Common.Validators
{
    public interface IValidator<T>
    {
        bool Validate(T document);
    }
}
