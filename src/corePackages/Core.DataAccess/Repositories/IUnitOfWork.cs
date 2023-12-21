﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync();
        bool Save();
    }
}