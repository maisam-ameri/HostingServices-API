using AutoMapper;
using Entities;
using Shared.DataTransferObjects;

namespace Host_Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Host, HostDto>();
            CreateMap<Plan, PlanDto>();
            CreateMap<Feature, FeatureDto>();
            CreateMap<HostForCreationDto, Entities.Host>();
            CreateMap<PlanForCreationDto, Plan>();
            CreateMap<FeatureForCreationDto, Feature>();
        }
    }
}
