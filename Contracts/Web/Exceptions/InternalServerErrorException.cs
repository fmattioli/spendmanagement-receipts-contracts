namespace Contracts.Web.Exceptions
{
    public sealed class InternalServerErrorException : Exception
    {
        public InternalServerErrorException(string message)
        {
            Data.Add(nameof(InternalServerErrorException), message);
        }

        public InternalServerErrorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public InternalServerErrorException()
        {
        }
    }
}
