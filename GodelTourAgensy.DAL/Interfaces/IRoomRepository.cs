using GodelTourAgensy.DAL.Entities;
using System.Collections.Generic;

namespace GodelTourAgensy.DAL.Interfaces
{
    public interface IRoomRepository
    {
        void Create(RoomEntity item);

        void Delete(RoomEntity item);

        IEnumerable<RoomEntity> GetAll();

        void Update(RoomEntity item);
    }
}
