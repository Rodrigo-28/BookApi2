namespace bookApi.Application.Exceptions
{
    public class ForbiddenException : CustomException
    {
        public ForbiddenException()
        {

        }
        public ForbiddenException(string message) : base(message)
        {

        }
    }
}
