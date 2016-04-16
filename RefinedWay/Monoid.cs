using System;

namespace RefinedWay
{
    public partial interface IMonoid<T>
    {
        T Unit { get; }

        Func<T, T, T> Operation { get; }
    }
    
    public class Monoid<T> : IMonoid<T>
    {
        public T Unit { get; private set; }
        public Func<T, T, T> Operation { get; private set; }

        public Monoid(T unit,Func<T, T, T> operation)
        {
            Operation = operation;
            Unit = unit;
        }
    }

    public static class MonoidExtensions
    {
        public static IMonoid<T> Monoid<T>(this T unit, Func<T, T, T> operation)
        {
            return new Monoid<T>(unit, operation);
        }
    }
}
