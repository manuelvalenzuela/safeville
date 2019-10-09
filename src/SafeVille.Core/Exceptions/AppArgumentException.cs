namespace SafeVille.Core.Exceptions
{
    public class AppArgumentException : AppException
    {
        private readonly string _message;

        public AppArgumentException(string message) : base(message)
        {
            ErrorCode = (int)ErrorCodes.NullException;
            _message = message;
        }

        public override string Message => $"{_message} is null...";
    }
}