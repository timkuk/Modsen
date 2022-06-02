using GodelTourAgensy.BLL.Models;
using GodelTourAgensy.DAL.Entities;
using System.Collections.Generic;

namespace GodelTourAgensy.BLL.Interfaces
{
    public interface IClientsService
    {
        string Check(ClientEntity item);

        void Create(ClientEntity item);

        void Delete(ClientEntity item);

        IEnumerable<ClientModel> Get();

        IEnumerable<ClientModel> Get(string name);

        ClientEntity GetById(int id);

        void Update(ClientEntity item);
    }
}
