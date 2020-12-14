using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using Dapper;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Abstractions
{
    public abstract class SuperRepository : Repository
    {
        protected readonly SQLiteConnection conn;

        public SuperRepository(IConfiguration configuration) : base(configuration)
        {
            conn = new SQLiteConnection(_connectionString);
        }

        public List<Entity> Query<Entity>(string sql, Dictionary<string, object> parameters = null)
        {
            try
            {
                conn.Open();
                var res = conn.Query<Entity>(sql, new DynamicParameters(parameters), null);
                return res.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Execute(string sql, Dictionary<string, object> parameters = null)
        {
            try
            {
                conn.Open();
                var res = conn.Execute(sql, new DynamicParameters(parameters), null);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
