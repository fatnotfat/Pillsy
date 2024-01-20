using AutoMapper;
using BusinessObject;
using Pillsy.DataTransferObjects.Patient.PatientDetailDto;

namespace Pillsy.Mappers
{
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<Schedule, Medication>()
            .ForMember(
                dest => dest.Start_date,
                opt => opt.MapFrom(src => src.DateStart)
            ).ForMember(
                dest => dest.End_date,
                opt => opt.MapFrom(src => src.DateEnd)
            );
        }
    }
}
