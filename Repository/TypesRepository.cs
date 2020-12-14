using System;
using System.Collections.Generic;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Repository.Abstractions;
using Dapper;

namespace Repository
{
    public class TypesRepository : SuperRepository, ITypesRepository
    {
        public TypesRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public int Create(Domain.Entities.Type p)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@TypeName", p.TypeName);

                int res = conn.Execute("insert into Types(TypeName) values(@TypeName)", param);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(int id)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@TypeID", id);

                int res = conn.Execute("delete from Types where TypeID = @TypeID", param);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Domain.Entities.Type> Get()
        {
            try
            {
                IEnumerable<Domain.Entities.Type> Types = conn.Query<Domain.Entities.Type>("Select * from Types",null);

                return Types.AsList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Domain.Entities.Type Get(int id)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@TypeID", id);

                IEnumerable<Domain.Entities.Type> Types = conn.Query<Domain.Entities.Type>("select * from Types where TypeID = @TypeID", param);
                List<Domain.Entities.Type> ts = Types.AsList();
                return ts.Count > 0 ? ts[0] : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Domain.Entities.Type Update(Domain.Entities.Type p)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@TypeID", p.TypeID);
                param.Add("@TypeName", p.TypeName);

                int res = conn.Execute("update Types set TypeName = @TypeName where TypeID = @TypeID", param);
                if (res != 0)
                {
                    return this.Get(p.TypeID);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
