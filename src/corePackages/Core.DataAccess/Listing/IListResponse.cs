using System.Collections;

namespace Core.DataAccess.Listing
{
    public interface IListResponse<T> 
    {
        IList<T> Data { get; }
    }
}
