using Core.DataAccess.Repositories;
using Domain.Models;

namespace Application.Repositories;

public interface IProductRepository : IAsyncRepository<Product>, IRepository<Product>, IBaseCustomRepository
{
}
