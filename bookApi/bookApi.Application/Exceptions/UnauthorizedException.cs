namespace bookApi.Application.Exceptions
{
    public class UnauthorizedException : CustomException
    {
        public UnauthorizedException()
        {

        }

        public UnauthorizedException(string message) : base(message)
        {

        }
    }
}
