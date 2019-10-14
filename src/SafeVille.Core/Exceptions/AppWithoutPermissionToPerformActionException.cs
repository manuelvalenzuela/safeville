namespace SafeVille.Core.Exceptions
{
    public class AppWithoutPermissionToPerformActionException : AppException
    {
        private readonly string _message;

        public AppWithoutPermissionToPerformActionException(string message) : base(message)
        {
            ErrorCode = (int)ErrorCodes.WithoutPermissionToPerformAction;
            _message = message;
        }

        public override string Message => $"{_message} does not have permission to perform the action...";
    }
}