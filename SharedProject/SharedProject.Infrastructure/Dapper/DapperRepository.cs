using System;
using System.Data;
using Dapper;

namespace SharedProject.Dapper
{
    public class DapperRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IDbConnection _connection;

        public DapperRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var tableName = typeof(TEntity).Name;
            return await _connection.QueryAsync<TEntity>($"SELECT * FROM {tableName}");
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var tableName = typeof(TEntity).Name;
            return await _connection.QuerySingleOrDefaultAsync<TEntity>($"SELECT * FROM {tableName} WHERE Id = @Id", new { Id = id });
        }

        public async Task AddAsync(TEntity entity)
        {
            var tableName = typeof(TEntity).Name;
            var insertSql = SqlBuilder.GenerateInsertSql(tableName, entity);

            await _connection.ExecuteAsync(insertSql, entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var tableName = typeof(TEntity).Name;
            var updateSql = SqlBuilder.GenerateUpdateSql(tableName, entity);

            await _connection.ExecuteAsync(updateSql, entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var tableName = typeof(TEntity).Name;
            await _connection.ExecuteAsync($"DELETE FROM {tableName} WHERE Id = @Id", new { Id = id });
        }

        public Task<int> ExecuteAsync(CommandType commandType, string sql, object parameters)
        {
            throw new NotImplementedException();
        }

        public Task ExecuteStoreProcedureAsync(string storedProcedure, object parameters)
        {
            throw new NotImplementedException();
        }
    }

}

