using System;
namespace RefinedWay
{
    public sealed class Success<L, A> : Validation<L, A>
    {
        Success(A value) : base(value)
        {
        }

        public static Success<L, A> FromSuccess(A value)
        {
            return new Success<L, A>(value);
        }
        public override bool IsSuccess()
        {
            return true;
        }

        public override Validation<L, B> Select<B>(Func<A, B> mapper)
        {
            return new Success<L, B>(mapper(Value));
        }

        public override Validation<L, B> SelectMany<B>(Func<A, Validation<L, B>> mapper)
        {
            return mapper(Value);
        }
    }
  }
