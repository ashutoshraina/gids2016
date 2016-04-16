using System;
namespace RefinedWay
{

public class ValidationMaybeT<T,U> : IValidation<T,U>
{
    public ValidationMaybeT(IMaybe<U> value, T error)
    {
        Value = value;
        Error = error;
    }

    public IValidation<T, V> Select<V>(Func<U, V> f)
    {
        return Value.Fold<IValidation<T, V>>(() => new ValidationError<T,V>(Error), s => new ValidationSuccess<T,V>(f(s)));
    }

    ValidationError<T, V> SelectManyError<V>()
    {
        return new ValidationError<T, V>(Error);
    }

    public IValidation<T, V> SelectMany<V>(Func<U, IValidation<T, V>> f)
    {
        return Value.Fold(() => SelectManyError <V>(), s => f(s));
    }

    public IMaybe<U> Value{ get; private set; }

    public T Error{ get; private set; }
}
}
