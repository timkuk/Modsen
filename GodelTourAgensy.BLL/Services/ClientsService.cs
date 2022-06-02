using GodelTourAgensy.BLL.Models;
using GodelTourAgensy.BLL.Interfaces;
using GodelTourAgensy.DAL.Entities;
using GodelTourAgensy.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;
using AutoMapper;

namespace GodelTourAgensy.BLL.Services
{
    public class ClientsService : IClientsService
    {
        private readonly IClientRepository _clientRepository;

        private readonly IMapper _mapper;

        public ClientsService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public string Check(ClientEntity item)
        {
            if (item.FullName == null)
            {
                return "The full name field is required";
            }
            if ((item.Bithday.Year <= 1900) || ((DateTime.Now.Year - item.Bithday.Year) < 18))
            {
                return "Incorrect date of birth";
            }
            if (item.Phone == null)
            {
                return "The phone field is required";
            }
            return null;
        }

        public void Create(ClientEntity item)
        {
            _clientRepository.Create(item);
        }

        public void Delete(ClientEntity item)
        {
            _clientRepository.Delete(item);
        }

        public IEnumerable<ClientModel> Get()
        {
            return _clientRepository.GetAll().Select(_mapper.Map<ClientEntity, ClientModel>);
        }

        public IEnumerable<ClientModel> Get(string name)
        {
            return _clientRepository.GetAll().Select(_mapper.Map<ClientEntity, ClientModel>);
        }

        public ClientEntity GetById(int id)
        {
            return _clientRepository.GetAll().FirstOrDefault(x => x.Id == id);
        }

        public void Update(ClientEntity item)
        {
            _clientRepository.Update(item);
        }
    }
}
