using Core.Application.GenericRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserFavouriteProductService
{
    public class UserFavouriteProductManager : IUserFavouriteProductService
    {
        IGenericRepository<UserFavouriteProduct> _userFavouriteProductRepository;

        public UserFavouriteProductManager(IGenericRepository<UserFavouriteProduct> userFavouriteProductRepository)
        {
            _userFavouriteProductRepository = userFavouriteProductRepository;
        }

        public async Task DeleteFavouritesByProduct(int productId)
        {
            var userFavouritesToDelete = await _userFavouriteProductRepository.GetListAsync(p => p.ProductId == productId);

            await _userFavouriteProductRepository.DeleteRangeAsync(userFavouritesToDelete.Data, true);
        }
    }
}
