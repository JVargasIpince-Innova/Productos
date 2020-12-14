using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contracts.Services
{
    public interface ITypesService
    {
        List<Domain.Entities.Type> Get();
        Domain.Entities.Type Get(int t);
        int Create(Domain.Entities.Type id);
        Domain.Entities.Type Update(Domain.Entities.Type id);
        int Delete(int id);
    }
}
