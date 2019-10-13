namespace SafeVille.Core.Exceptions
{
    /// <summary>
    /// The exception that is thrown when one of the arguments provided to a method is not valid
    /// </summary>
    public class AppArgumentException : AppException
    {
        private readonly string _message;

        public AppArgumentException(string message) : base(message)
        {
            ErrorCode = (int)ErrorCodes.ArgumentException;
            _message = message;
        }

        public override string Message => $"{_message} is null, empty or has no elements...";
    }
}