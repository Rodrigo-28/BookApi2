namespace bookApi.Application.Exceptions
{
    public class CustomException : Exception
    {
        public string ErrorCode { get; set; }

        public CustomException()
        {

        }
        public CustomException(string message) : base(message)
        {

        }
    }
}
