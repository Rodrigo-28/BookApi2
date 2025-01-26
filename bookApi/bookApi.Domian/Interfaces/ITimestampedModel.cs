namespace bookApi.Domian.Interfaces
{
    public interface ITimestampedModel
    {
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
