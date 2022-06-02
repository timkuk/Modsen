using GodelTourAgensy.BLL.Models;
using GodelTourAgensy.DAL.Entities;
using System.Collections.Generic;

namespace GodelTourAgensy.BLL.Interfaces
{
    public interface  IPackagesService
    {
        void Update(TravelPackageEntity item);

        void Create(TravelPackageEntity item);

        string Check(TravelPackageEntity order);

        void Delete(TravelPackageEntity order);

        IEnumerable<TravelPackageModel> Get();

        TravelPackageEntity GetById(int id);

        IEnumerable<TravelPackageModel> GetAllById(int id);

        IEnumerable<(int Name, int Count)> GetMostPopular();
    }
}
