using GodelTourAgensy.DAL.Entities;
using System.Collections.Generic;

namespace GodelTourAgensy.DAL.Interfaces
{
    public interface ITravelPackageRepository
    {
        void Create(TravelPackageEntity item);

        void Delete(TravelPackageEntity order);

        void Update(TravelPackageEntity item);

        IEnumerable<TravelPackageEntity> GetAll();
    }
}
