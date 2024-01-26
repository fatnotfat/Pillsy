using AutoMapper;
using BusinessObject;
using Pillsy.DataTransferObjects.Prescription.PrescriptionCreateDto;

namespace Pillsy.Mappers
{
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<Schedule, Medication_records>()
            .ForMember(
                dest => dest.Start_date,
                opt => opt.MapFrom(src => src.DateStart)
            ).ForMember(
                dest => dest.End_date,
                opt => opt.MapFrom(src => src.DateEnd)
            );

            CreateMap<Medication_records, Schedule>()
            .ForMember(
                dest => dest.DateStart,
                opt => opt.MapFrom(src => src.Start_date)
            ).ForMember(
                dest => dest.DateEnd,
                opt => opt.MapFrom(src => src.End_date)
            );
        }
    }
}
