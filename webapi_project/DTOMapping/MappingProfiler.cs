using AutoMapper;
using webapi_project.Models;
using webapi_project.Models.DTO;

namespace webapi_project.DTOMapping
{
    public class MappingProfiler: Profile
    {
        public MappingProfiler()
        {
            CreateMap<NationalParkDTO, NationalPark>().ReverseMap();
            CreateMap<trail,TrailDTO>().ReverseMap();
        }
    }
}
