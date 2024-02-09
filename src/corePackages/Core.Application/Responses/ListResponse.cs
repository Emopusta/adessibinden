using Core.DataAccess.Listing;

namespace Core.Application.Responses;

public class ListResponse<T> : BaseListingModel, IResponse
{
    public IList<T> Items
    {
        get => _items ??= new List<T>();
        set => _items = value;
    }

    private IList<T>? _items;
}
