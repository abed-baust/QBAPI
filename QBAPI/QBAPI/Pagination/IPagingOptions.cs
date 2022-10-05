namespace CB.Utility.Pagination
{
    public interface IPagingOptions
    {
        int? Offset { get; set; }
        int? Limit { get; set; }
    }
}
