namespace Core.DataAccess.Listing;

public interface IListResponse<T> 
{
    IList<T> Items { get; }
}
