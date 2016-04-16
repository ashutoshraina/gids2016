using System;
using System.Collections.Generic;

namespace ErrorsInAsyncWorld
{

    public class Result
    {
        protected bool success;
        readonly Exception exception;
        readonly string message;

        public bool Success {
            get {
                return success;
            }
        }

        public Exception Exception {
            get {
                return exception;
            }
        }

        public string Message {
            get {
                return message;
            }
        }

        public bool Fail {
            get {
                return !success;
            }
        }

        public static Result<T> FromResult<T>(T result) { return new Result<T>(result, true); }
        public static Result<T> FromException<T>(Exception exception) { return new Result<T>(exception); }
        public static Result<T> FromMessage<T>(string message) { return new Result<T>(message); }
        public static Result<T> FromSuccess<T>(bool success) { return new Result<T>(success); }

        protected Result(string message)
        {
            success = false;
            this.message = message;
        }
        protected Result(Exception exception)
        {
            success = false;
            this.exception = exception;
        }
        Result(bool success)
        {
            this.success = success;
        }

        public Result() : this(true)
        {
        }

        public static Result<T> Combine<T>(IEnumerable<Result<T>> results)
        {
            foreach (Result<T> result in results)
            {
                if (result.Fail)
                    return result;
            }

            return new Result<T>();
        }

    }
}
