namespace SafeVille.Core.Exceptions
{
    public class AppNotFoundException : AppException
    {
        private readonly string _message;

        public AppNotFoundException(string message) : base(message)
        {
            ErrorCode = (int)ErrorCodes.NotFound;
            _message = message;
        }

        public override string Message => $"{_message} was not found...";
    }
}