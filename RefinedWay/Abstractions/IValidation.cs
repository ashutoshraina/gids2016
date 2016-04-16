using System;
namespace RefinedWay
{

    public interface IValidation<T, U>
    {
        IValidation<T, V> Select<V>(Func<U, V> f);

        IValidation<T, V> SelectMany<V>(Func<U, IValidation<T, V>> f);
    }

}
