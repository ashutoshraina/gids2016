using System;

namespace RefinedWay
{
    public class ValidationError<T, U> : IValidation<T, U>
    {
        public T Error { get; private set; }

        public ValidationError(T error)
        {
            Error = error;
        }

        public IValidation<T, V> Select<V>(Func<U, V> f) => new ValidationError<T, V>(Error);
        public IValidation<T, V> SelectMany<V>(Func<U, IValidation<T, V>> f) => new ValidationError<T, V>(Error);

    }
}
