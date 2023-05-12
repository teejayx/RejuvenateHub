using System;
using System.Data;

namespace SharedProject.Dapper
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
        Task<int> ExecuteAsync(CommandType commandType, string sql, object parameters);
        Task ExecuteStoreProcedureAsync(string storedProcedure, object parameters);
    }
}

