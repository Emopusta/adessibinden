using Core.DataAccess.Repositories;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AdessibindenContext _dbContext;

        public UnitOfWork(AdessibindenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Save()
        {
            var result = await _dbContext.SaveChangesAsync()>0;

            return result;

        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }


    }
}
