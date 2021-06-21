﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Services.Repository
{
    public interface IRepositoryService
    {
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;

        Task AddAsync<T>(T entity) where T : class;

        Task DeleteAsync<T>(T entity) where T : class;

        Task UpdateAsync<T>(T entity) where T : class;
    }
}
