using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public class TypesService : ITypesService
    {
        private readonly ITypesRepository _typesRepo;

        public TypesService(ITypesRepository typesRepo)
        {
            this._typesRepo = typesRepo;
        }
        public int Create(Domain.Entities.Type t)
        {
            try
            {
                var res = _typesRepo.Create(t);
                return res;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Delete(int id)
        {
            try
            {
                var res = _typesRepo.Delete(id);
                return res;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Domain.Entities.Type> Get()
        {
            try
            {
                var res = _typesRepo.Get();
                return res;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Domain.Entities.Type Get(int id)
        {
            try
            {
                var res = _typesRepo.Get(id);
                return res;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Domain.Entities.Type Update(Domain.Entities.Type t)
        {
            try
            {
                var res = _typesRepo.Update(t);
                return res;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
