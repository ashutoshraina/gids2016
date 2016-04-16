using System;
namespace RefinedWay
{
    public sealed class Success<L, A> : Validation<L, A>
    {
        Success(A value) : base(value)
        {
        }

        public static Success<L, A> FromSuccess(A value) => new Success<L, A>(value);

        public override bool IsSuccess() => true;

        public override Validation<L, B> Select<B>(Func<A, B> mapper) => new Success<L, B>(mapper(Value));

        public override Validation<L, B> SelectMany<B>(Func<A, Validation<L, B>> mapper) => mapper(Value);
    }
  }
