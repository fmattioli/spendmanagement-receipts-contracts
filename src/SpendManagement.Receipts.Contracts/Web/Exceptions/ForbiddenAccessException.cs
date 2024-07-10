namespace Contracts.Web.Exceptions
{
    public class ForbiddenAccessException : Exception
    {
        public ForbiddenAccessException(string message)
        {
            Data.Add(nameof(BadRequestException), message);
        }

        public ForbiddenAccessException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public ForbiddenAccessException()
        {
        }
    }
}
