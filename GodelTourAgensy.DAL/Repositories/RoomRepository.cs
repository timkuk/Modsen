using GodelTourAgensy.DAL.Entities;
using GodelTourAgensy.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GodelTourAgensy.DAL.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly GodelTourAgensyContext _db;

        public RoomRepository(GodelTourAgensyContext db)
        {
            _db = db;
        }

        public void Delete(RoomEntity item)
        {
            if (_db.TravelPackageEntitys.Any(x => x.RoomId == item.Id))
            {
                throw new Exception("It is not possible to delete this room while there are related vouchers with it");
            }
            _db.RoomEntitys.Remove(item);
            _db.SaveChanges();
        }

        public void Create(RoomEntity item)
        {
            _db.RoomEntitys.Add(item);
            _db.SaveChanges();
        }

        public void Update(RoomEntity item)
        {
            _db.RoomEntitys.Update(item);
            _db.SaveChanges();
        }

        public IEnumerable<RoomEntity> GetAll()
        {
            return _db.RoomEntitys.ToList();
        }
    }
}

