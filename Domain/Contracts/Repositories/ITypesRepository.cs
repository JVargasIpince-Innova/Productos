using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Contracts.Repositories
{
    public interface ITypesRepository
    {
        List<Domain.Entities.Type> Get();
        Domain.Entities.Type Get(int t);
        int Create(Domain.Entities.Type id);
        Domain.Entities.Type Update(Domain.Entities.Type id);
        int Delete(int id);
    }
}
