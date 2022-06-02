using GodelTourAgensy.DAL.Entities;
using System.Collections.Generic;

namespace GodelTourAgensy.DAL.Interfaces
{
    public interface IClientRepository
    {
        void Create(ClientEntity item);

        void Delete(ClientEntity item);

        IEnumerable<ClientEntity> GetAll();

        void Update(ClientEntity item);
    }
}
