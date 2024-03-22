using Application.Repositories;
using Core.DataAccess.Repositories;
using DataAccess.Contexts;
using Domain.Models;

namespace DataAccess.Repositories;

public class ProductRepository : EfRepositoryBase<Product, AdessibindenContext>, IProductRepository
{
    public ProductRepository(AdessibindenContext context) : base(context)
    {
    }
}
