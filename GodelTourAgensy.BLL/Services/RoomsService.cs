using GodelTourAgensy.BLL.Models;
using GodelTourAgensy.BLL.Interfaces;
using GodelTourAgensy.DAL.Entities;
using GodelTourAgensy.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace GodelTourAgensy.BLL.Services
{
    public class RoomsService : IRoomsService
    {
        private readonly IRoomRepository _roomRepository;

        private readonly IMapper _mapper;

        public RoomsService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public string Check(RoomEntity item)
        {
            if (item.Number < 0)
            {
                return "The room number field must be mandatory";
            }
            if (item.Price < 0)
            {
                return "The price field must be mandatory";
            }

            return null;
        }

        public void Create(RoomEntity item)
        {
            _roomRepository.Create(item);
        }

        public void Delete(RoomEntity item)
        {
            _roomRepository.Delete(item);
        }

        public IEnumerable<RoomModel> Get()
        {
            return _roomRepository.GetAll().Select(_mapper.Map<RoomEntity, RoomModel>);
        }

        public IEnumerable<RoomModel> Get(string name)
        {
            return _roomRepository.GetAll().Select(_mapper.Map<RoomEntity, RoomModel>);
        }

        public RoomEntity GetById(int id)
        {
            return _roomRepository.GetAll().FirstOrDefault(x => x.Id == id);
        }

        public void Update(RoomEntity item)
        {
            _roomRepository.Update(item);
        }
    }
}
