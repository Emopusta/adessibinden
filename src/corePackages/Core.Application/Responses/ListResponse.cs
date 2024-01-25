using Core.Application.Dtos;
using Core.DataAccess.Listing;

namespace Core.Application.Responses
{
    public class ListResponse<T> : BaseListingModel, IResponse
    {
        public IList<T> Data
        {
            get => _data ??= new List<T>();
            set => _data = value;
        }

        private IList<T>? _data;
    }
}
