using System.Collections.Generic;

namespace Api
{
    public class Result<T>
    {
        private Result(T value)
        {
            WasSuccessful = true;
            Value = value;
        }

        private Result(IEnumerable<string> errors)
        {
            WasSuccessful = false;
            Errors = errors;
        }

        private Result(string error)
        {
            WasSuccessful = false;
            Errors = new[] { error };
        }

        public bool WasSuccessful { get; }

        public T Value { get; }

        public IEnumerable<string> Errors { get; }

        public static Result<T> Success(T value) =>
            new Result<T>(value);

        public static Result<T> Fail(string error) =>
            new Result<T>(error);

        public static Result<T> Fail(IEnumerable<string> errors) =>
            new Result<T>(errors);
    }
}