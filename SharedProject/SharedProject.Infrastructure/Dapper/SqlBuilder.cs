using System;
namespace SharedProject.Dapper
{
    public static class SqlBuilder
    {
        public static string GenerateInsertSql(string tableName, object entity)
        {
            var properties = entity.GetType().GetProperties();
            var columns = string.Join(", ", properties.Select(p => p.Name));
            var values = string.Join(", ", properties.Select(p => $"@{p.Name}"));

            return $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
        }

        public static string GenerateUpdateSql(string tableName, object entity)
        {
            var properties = entity.GetType().GetProperties();
            var setClause = string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));

            return $"UPDATE {tableName} SET {setClause} WHERE Id = @Id";
        }
    }

}

