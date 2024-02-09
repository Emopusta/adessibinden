namespace Core.DataAccess.Listing;

public class Listing<T> : IListResponse<T>
{
    public IList<T> Items { get; set; }
}
