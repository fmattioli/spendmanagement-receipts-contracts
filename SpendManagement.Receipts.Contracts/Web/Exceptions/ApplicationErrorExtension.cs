namespace Contracts.Web.Exceptions
{
    public readonly class ApplicationErrorExtension
    {
        public readonly async Task<T> HandleExceptions<T>(this Task<T> task, string requestName)
           where T : class
        {
            try
            {
                return await task;
            }
            catch (HttpRequestException e) when (e.Message.Contains("404"))
            {
                throw new BadRequestException(requestName + " " + e.Message, e.InnerException);
            }
            catch (HttpRequestException e) when (e.Message.Contains("500"))
            {
                throw new InternalServerErrorException(requestName + " " + e.Message, e.InnerException);
            }
            catch (Exception e)
            {
                throw new InternalServerErrorException(e.Message);
            }
        }
    }
}
