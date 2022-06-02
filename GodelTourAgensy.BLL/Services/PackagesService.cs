using GodelTourAgensy.BLL.Models;
using GodelTourAgensy.BLL.Interfaces;
using GodelTourAgensy.DAL.Entities;
using GodelTourAgensy.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using GodelTourAgensy.DAL;
using AutoMapper;

namespace GodelTourAgensy.BLL.Services
{
    public class PackagesService : IPackagesService
    {
        private readonly GodelTourAgensyContext _db;

        private readonly ITravelPackageRepository _travelPackageRepository;

        private readonly IMapper _mapper;

        public PackagesService(ITravelPackageRepository travelPackageRepository, IMapper mapper, GodelTourAgensyContext db)
        {
            _travelPackageRepository = travelPackageRepository;
            _mapper = mapper;
            _db = db;
        }

        public string Check(TravelPackageEntity order)
        {
            if (!_db.ClientEntitys.Any(x => x.Id == order.ClientId))
            {
                return "Not Found Client";
            }
            if (order.EndDate < order.StartDate)
            {
                return "The start date of the tour cannot be less than the end";
            }
            if (order.EndDate.Year <= 1753)
            {
                return "Incorrect Data";
            }
            return null;
        }

        public void Update(TravelPackageEntity item)
        {
            _travelPackageRepository.Update(item);
        }

        public void Create(TravelPackageEntity item)
        {
            _travelPackageRepository.Create(item);
        }

        public void Delete(TravelPackageEntity order)
        {
            _travelPackageRepository.Delete(order);
        }

        public IEnumerable<TravelPackageModel> Get()
        {
            return _travelPackageRepository.GetAll().Select(_mapper.Map<TravelPackageEntity, TravelPackageModel>);
        }

        public TravelPackageEntity GetById(int id)
        {
            return _travelPackageRepository.GetAll().First(x => x.Id == id);
        }

        public IEnumerable<TravelPackageModel> GetAllById(int id)
        {
            return _travelPackageRepository.GetAll().Select(_mapper.Map<TravelPackageEntity, TravelPackageModel>).Where(x => x.ClientId == id);
        }

        public IEnumerable<(int Name, int Count)> GetMostPopular()
        {
            var relaxes = _db.RoomEntitys.ToList();
            var packages = _db.TravelPackageEntitys.ToList().GroupBy(x => x.RoomId);

            return packages.Select(x => (x.Key, x.ToList().Count))
                .Select(x => (relaxes.First(r => r.Id == x.Key).Number, x.Count))
                .OrderByDescending(x => x.Count);
        }
    }
}
