using Core.DataAccess.Repositories;
using Domain.Models;

namespace Application.Repositories;

public interface IPhoneProductRepository : IAsyncRepository<PhoneProduct>, IRepository<PhoneProduct>, IBaseCustomRepository
{
    Task<List<PhoneProduct>> GetTenMostExpensive();
}
