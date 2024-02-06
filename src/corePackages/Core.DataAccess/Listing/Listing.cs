namespace Core.DataAccess.Listing;

public class Listing<T> : IListResponse<T>
{
    public IList<T> Data { get; set; }
}
