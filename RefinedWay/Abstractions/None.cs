using System;
namespace RefinedWay
{

    public class None<T> : IMaybe<T>
    {
        public IMaybe<U> Select<U>(Func<T, U> f)
        {
            return new None<U>();
        }

        public IMaybe<U> SelectMany<U>(Func<T, IMaybe<U>> f)
        {
            return new None<U>();
        }

        public U Fold<U>(Func<U> error, Func<T, U> success)
        {
            return error();
        }

        public IValidation<U, T> ToValidationT<U>(U exceptionalValue)
        {
            return new ValidationMaybeT<U, T>(this, exceptionalValue);
        }
    }

}
