namespace CB.Utility.Pagination
{
    public class PagingOptions : IPagingOptions
    {
        public int? Offset { get; set; }
        public int? Limit { get; set; }

        public PagingOptions()
        {
            Offset = Offset == null ? 0 : Offset;
            Limit = Limit == null ? 10 : Limit;
        }
    }
}
