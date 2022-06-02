using GodelTourAgensy.DAL.Entities;
using GodelTourAgensy.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GodelTourAgensy.DAL.Repositories
{
    public class AdditionalServiceRepository : IAdditionalServiceRepository
    {
        private readonly GodelTourAgensyContext _db;

        public AdditionalServiceRepository(GodelTourAgensyContext db)
        {
            _db = db;
        }

        public void Delete(AdditionalServiceEntity item)
        {
            if (_db.IntermidiateServiceEntitys.Any(x => x.ServiceId == item.Id))
            {
                throw new Exception();
            }
            _db.AdditionalServiceEntitys.Remove(item);
            _db.SaveChanges();
        }

        public void Create(AdditionalServiceEntity item)
        {
            _db.AdditionalServiceEntitys.Add(item);
            _db.SaveChanges();
        }

        public void Update(AdditionalServiceEntity item)
        {
            _db.AdditionalServiceEntitys.Update(item);
            _db.SaveChanges();
        }

        public AdditionalServiceEntity GetById(int id)
        {
            return _db.AdditionalServiceEntitys.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<AdditionalServiceEntity> GetAll()
        {
            return _db.AdditionalServiceEntitys.ToList();
        }
    }
}
