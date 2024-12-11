namespace bookApi.Domian.Common
{
    public class GenericListResponse<T>
    {
        public int Total { get; set; }
        public int Page { get; set; }
        public int Length { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
