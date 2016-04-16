using System;
namespace RefinedWay
{

    public sealed class Failure<L, A> : Validation<L, A>
    {
        readonly L left;

        public Failure(L left, A value) : base(value)
        {
            this.left = left;
        }

        public override bool IsSuccess()
        {
            return false;
        }

        public static Validation<L, B> FromFailure<B>(L left, B value)
        {
            return new Failure<L, B>(left, value);
        }

        public override Validation<L, B> Select<B>(Func<A, B> mapper)
        {
            return FromFailure(left, mapper(Value));
        }

        public override Validation<L, B> SelectMany<B>(Func<A, Validation<L, B>> mapper)
        {
            Validation<L, B> result = mapper(Value);
            return result.IsSuccess() ? FromFailure(left, result.Value) : FromFailure((result as Failure<L, B>).left, result.Value);
        }

    }
}