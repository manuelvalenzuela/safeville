namespace SafeVille.Core.Exceptions
{
    using System;

    public class AppException : Exception
    {
        public AppException(string message) : base(message)
        {
        }

        protected enum ErrorCodes
        {
            NullException = 1,
            ArgumentException = 2,
            AlreadyExistsException = 3
        }

        public int ErrorCode { get; protected set; }

        public dynamic ApiReturn => new { ErrorCode, Message };
    }
}