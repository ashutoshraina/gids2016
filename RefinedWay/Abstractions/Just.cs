using System;
namespace RefinedWay
{

public class Just<T> : IMaybe<T>
{
    public Just(T value)
    {
        this.value = value;

    }

    public IMaybe<U> Select<U>(Func<T, U> f)
    {
        return f(value).ToMaybe();
    }

    public IMaybe<U> SelectMany<U>(Func<T, IMaybe<U>> f)
    {
        return f(value);
    }

    public U Fold<U>(Func<U> error, Func<T,U> success)
    {
        return success(value);
    }

    public IValidation<U,T> ToValidationT<U>()
    {
        return new ValidationMaybeT<U,T>(this, default(U));
    }

    private readonly T value;
}

}
