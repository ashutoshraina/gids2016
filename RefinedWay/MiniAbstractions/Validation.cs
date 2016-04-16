using System;
namespace RefinedWay
{

    public abstract class Validation<L, A>
    {
        public A Value { get; }
        protected Validation(A value)
        {
            this.Value = value;
        }

        public abstract Validation<L, B> Select<B>(Func<A, B> mapper);
        public abstract Validation<L, B> SelectMany<B>(Func<A, Validation<L, B>> mapper);
        public abstract bool IsSuccess();
    }

}
