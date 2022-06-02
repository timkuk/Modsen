using GodelTourAgensy.BLL.Models;
using GodelTourAgensy.BLL.Interfaces;
using GodelTourAgensy.DAL.Entities;
using GodelTourAgensy.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace GodelTourAgensy.BLL.Services
{
    public class AdditionalsService : IAdditionalsService
    {
        private readonly IAdditionalServiceRepository _additionalServiceRepository;

        private readonly IMapper _mapper;

        public AdditionalsService(IAdditionalServiceRepository additionalServiceRepository, IMapper mapper)
        {
            _additionalServiceRepository = additionalServiceRepository;
            _mapper = mapper;
        }

        public string Check(AdditionalServiceEntity item)
        {
             if (item.Name == null)
             {
                 return "The name field is required";
             }
             if (item.Price < 0)
             {
                 return "The price field must be non-negative";
             }
             return null;
        }

        public void Create(AdditionalServiceEntity item)
        {
            _additionalServiceRepository.Create(item);
        }

        public void Delete(AdditionalServiceEntity item) 
        {
            _additionalServiceRepository.Delete(item);
        }

        public IEnumerable<AdditionalServiceModel> Get()
        {
            return _additionalServiceRepository.GetAll().Select(_mapper.Map<AdditionalServiceEntity, AdditionalServiceModel>);
        }

        public IEnumerable<AdditionalServiceModel> Get(string name)
        {
            return _additionalServiceRepository.GetAll().Select(_mapper.Map<AdditionalServiceEntity, AdditionalServiceModel>);
        }

        public AdditionalServiceEntity GetById(int id)
        {
            return _additionalServiceRepository.GetAll().FirstOrDefault(x => x.Id == id); ;
        }

        public void Update(AdditionalServiceEntity item)
        {
            _additionalServiceRepository.Update(item);
        }
    }
}
