using System;
namespace RefinedWay
{

    public class ValidationSuccess<T, U> : IValidation<T, U>
    {
        public ValidationSuccess(U value)
        {
            Result = value;
        }

        public IValidation<T, V> Select<V>(Func<U, V> f)
        {
            return new ValidationSuccess<T, V>(f(Result));
        }

        public IValidation<T, V> SelectMany<V>(Func<U, IValidation<T, V>> f)
        {
            return f(Result);
        }

        public U Result { get; private set; }
    }
}
