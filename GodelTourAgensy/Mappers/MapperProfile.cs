using AutoMapper;
using GodelTourAgensy.BLL.Models;
using GodelTourAgensy.Models;

namespace GodelTourAgensy.Web.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AdditionalServiceModel, AdditionalServiceViewModel>().ReverseMap();
            CreateMap<ClientModel, ClientViewModel>().ReverseMap();
            CreateMap<RoomModel, RoomViewModel>().ReverseMap();
            CreateMap<TravelPackageModel, TravelPackageViewModel>().ReverseMap();
        }
    }
}