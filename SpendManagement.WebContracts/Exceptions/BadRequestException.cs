namespace Web.Contracts.Exceptions
{
    public sealed class BadRequestException : Exception
    {
        public BadRequestException(string message)
        {
            Data.Add(nameof(BadRequestException), message);
        }

        public BadRequestException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public BadRequestException()
        {
        }
    }
}
