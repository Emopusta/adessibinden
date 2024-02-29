using Application.Repositories;
using Core.DataAccess.Repositories;
using DataAccess.Contexts;
using Domain.Models;

namespace DataAccess.Repositories;

public class PhoneProductRepository : EfRepositoryBase<PhoneProduct, AdessibindenContext>, IPhoneProductRepository
{
    private readonly AdessibindenContext _context;
    public PhoneProductRepository(AdessibindenContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<PhoneProduct>> GetTenMostExpensive()
    {
        using (var context = _context)
        {
            var result = (from pp in context.PhoneProducts
                          orderby pp.Price descending
                          select pp).Take(10);

            return result.ToList();
        }
    }
}
