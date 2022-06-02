using GodelTourAgensy.DAL.Entities;
using System.Collections.Generic;

namespace GodelTourAgensy.DAL.Interfaces
{
    public interface IAdditionalServiceRepository
    {
        void Create(AdditionalServiceEntity item);

        void Delete(AdditionalServiceEntity item);

        IEnumerable<AdditionalServiceEntity> GetAll();

        void Update(AdditionalServiceEntity item);
    }
}
