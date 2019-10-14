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
            ArgumentException,
            NotFound,
            WithoutPermissionToPerformAction
        }

        public int ErrorCode { get; protected set; }

        public dynamic ApiReturn => new { ErrorCode, Message };
    }
}