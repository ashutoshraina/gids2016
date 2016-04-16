using System;

namespace ErrorsInAsyncWorld
{

    public static class ResultExtensions
    {
        public static Result<T> OnSuccess<T>(this Result<T> result, Func<Result<T>> func)
        {
            if (result.Fail)
            {
                return result;

            }
            return func();
        }

        public static Result<T> OnSuccess<T>(this Result<T> result, Action action)
        {
            if (result.Fail)
                return result;

            action();

            return Result.FromSuccess<T>(true);
        }

        public static Result<T> OnSuccess<T>(this Result<T> result, Action<T> action)
        {
            if (result.Fail)
                return result;

            action(result.Value);

            return Result.FromSuccess<T>(true);
        }

        public static Result<T> OnFailure<T>(this Result<T> result, Func<Result<T>> func)
        {
            if (!result.Fail)
            {
                return result;

            }
            return func();
        }

        public static Result<T> OnFailure<T>(this Result<T> result, Action action)
        {
            if (!result.Fail)
                return result;

            action();

            return Result.FromSuccess<T>(false);
        }

        public static Result<T> OnFailure<T>(this Result<T> result, Action<T> action)
        {
            if (!result.Fail)
                return result;

            action(result.Value);

            return Result.FromSuccess<T>(false);
        }
    }      
}
