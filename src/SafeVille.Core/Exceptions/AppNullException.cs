namespace SafeVille.Core.Exceptions
{
    public class AppNullException : AppException
    {
        private readonly string _message;

        public AppNullException(string message) : base(message)
        {
            ErrorCode = (int)ErrorCodes.NullException;
            _message = message;
        }

        public override string Message => $"{_message} is null...";
    }
}