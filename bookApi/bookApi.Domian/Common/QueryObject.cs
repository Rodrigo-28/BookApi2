namespace bookApi.Domian.Common
{
    public class QueryObject
    {
        public string Search { get; set; }
        public List<SortOption> Sorts { get; set; } = new List<SortOption>();
        public List<FilterOption> Filters { get; set; } = new List<FilterOption>();
    }
}
