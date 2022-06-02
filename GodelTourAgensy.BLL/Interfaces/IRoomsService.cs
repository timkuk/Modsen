using GodelTourAgensy.BLL.Models;
using GodelTourAgensy.DAL.Entities;
using System.Collections.Generic;

namespace GodelTourAgensy.BLL.Interfaces
{
    public interface IRoomsService
    {
        string Check(RoomEntity item);

        void Create(RoomEntity item);

        void Delete(RoomEntity item);

        IEnumerable<RoomModel> Get();

        IEnumerable<RoomModel> Get(string name);

        RoomEntity GetById(int id);

        void Update(RoomEntity item);
    }
}
