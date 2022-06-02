using AutoMapper;
using GodelTourAgensy.BLL.Models;
using GodelTourAgensy.DAL.Entities;

namespace GodelTourAgensy.BLL.Mappers
{
    public class MapperProfile : Profile
    {
       public MapperProfile()
       {
            CreateMap<AdditionalServiceEntity, AdditionalServiceModel>().ReverseMap();
            CreateMap<ClientEntity, ClientModel>().ReverseMap();
            CreateMap<RoomEntity, RoomModel>().ReverseMap();
            CreateMap<TravelPackageEntity, TravelPackageModel>().ReverseMap();
        }
    }
}
