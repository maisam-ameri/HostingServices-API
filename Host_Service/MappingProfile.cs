using AutoMapper;
using Entities;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Host_Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Host, HostDto>();
            CreateMap<HostForCreationDto, Entities.Host>();
            CreateMap<HostForUpdateDto, Entities.Host>();

            CreateMap<Plan, PlanDto>();
            CreateMap<PlanForCreationDto, Plan>();
            CreateMap<PlanForUpdateDto, Plan>().ReverseMap();

            CreateMap<Feature, FeatureDto>();
            CreateMap<FeatureForCreationDto, Feature>();
            CreateMap<FeatureForUpdateDto, Feature>().ReverseMap();

            CreateMap<UserForRegisterationDto, User>();
        }
    }
}
