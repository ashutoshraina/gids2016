using System;
namespace ErrorsAsFirstClassCitizens
{
    public sealed class Result<T> : Result
    {
        readonly T value;

        public T Value {
            get {
                return value;
            }
        }
        public Result()
        {
            success = true;
            value = default(T);
        }
        
        public Result(bool success)
        {
            this.success = success;
        }

        public Result(T result, bool success)
        {
            success = true;
            value = result;
        }

        public Result(Exception exception) : base(exception)
        {
        }

        public Result(string message) : base(message)
        {
        }
    }

}
