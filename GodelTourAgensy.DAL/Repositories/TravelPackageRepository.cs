using System.Linq;
using GodelTourAgensy.DAL.Entities;
using GodelTourAgensy.DAL.Interfaces;
using System.Collections.Generic;

namespace GodelTourAgensy.DAL.Repositories
{
    public class TravelPackageRepository : ITravelPackageRepository
    {
        private readonly GodelTourAgensyContext _db;

        public TravelPackageRepository(GodelTourAgensyContext db)
        {
            _db = db;
        }

        public void Delete(TravelPackageEntity order)
        {
            var services = _db.IntermidiateServiceEntitys.ToList().Where(x => x.TravelId == order.Id);
            _db.IntermidiateServiceEntitys.RemoveRange(services);
            _db.SaveChanges();
            _db.TravelPackageEntitys.Remove(order);
            _db.SaveChanges();
        }

        public void Create(TravelPackageEntity item)
        {
            _db.TravelPackageEntitys.Add(item);
            _db.SaveChanges();
        }

        public void Update(TravelPackageEntity item)
        {
            _db.TravelPackageEntitys.Update(item);
            _db.SaveChanges();
        }

        public IEnumerable<TravelPackageEntity> GetAll()
        {
            return _db.TravelPackageEntitys.ToList();
        }
    }
}

