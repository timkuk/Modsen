using GodelTourAgensy.BLL.Models;
using GodelTourAgensy.DAL.Entities;
using System.Collections.Generic;

namespace GodelTourAgensy.BLL.Interfaces
{
    public interface IAdditionalsService
    {
        string Check(AdditionalServiceEntity item);

        void Create(AdditionalServiceEntity item);

        void Delete(AdditionalServiceEntity item);

        IEnumerable<AdditionalServiceModel> Get();

        IEnumerable<AdditionalServiceModel> Get(string name);

        AdditionalServiceEntity GetById(int id);

        void Update(AdditionalServiceEntity item);
    }
}
