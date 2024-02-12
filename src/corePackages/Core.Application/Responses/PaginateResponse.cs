using Core.DataAccess.Paging;

namespace Core.Application.Responses;

public class PaginateResponse<T> : BasePageableModel, IResponse
{
    public IList<T> Items
    {
        get => _items ??= new List<T>();
        set => _items = value;
    }

    private IList<T>? _items;
}
