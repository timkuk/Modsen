using System.Linq;
using GodelTourAgensy.DAL.Entities;
using GodelTourAgensy.DAL.Interfaces;
using System.Collections.Generic;

namespace GodelTourAgensy.DAL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly GodelTourAgensyContext _db;

        public ClientRepository(GodelTourAgensyContext db)
        {
            _db = db;
        }

        public void Delete(ClientEntity item)
        {
            if (_db.TravelPackageEntitys.Any(x => x.ClientId == item.Id))
            {
                
            }
            _db.ClientEntitys.Remove(item);
            _db.SaveChanges();
        }

        public void Create(ClientEntity item)
        {
            _db.ClientEntitys.Add(item);
            _db.SaveChanges();
        }

        public void Update(ClientEntity item)
        {
            _db.ClientEntitys.Update(item);
            _db.SaveChanges();
        }

        public ClientEntity GetById(int id)
        {
            return _db.ClientEntitys.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ClientEntity> GetAll()
        {
            return _db.ClientEntitys.ToList();
        }
    }
}

