using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.Listing;

public static class IListingQueryableExtensions
{

    public static async Task<IListResponse<T>> ToListResponseAsync<T>(this IQueryable<T> source, CancellationToken cancellationToken)
    {
        var list = await source.ToListAsync(cancellationToken).ConfigureAwait(false);
        Listing<T> response = new() { Items = list };
        return response;
    }
}
