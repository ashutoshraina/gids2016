using System;
namespace RefinedWay
{

    public interface IMaybe<T>
    {
        IMaybe<U> Select<U>(Func<T, U> f);

        IMaybe<U> SelectMany<U>(Func<T, IMaybe<U>> f);

        U Fold<U>(Func<U> error, Func<T, U> success);
    }

}
