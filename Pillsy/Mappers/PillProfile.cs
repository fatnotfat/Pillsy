using AutoMapper;
using BusinessObject;
using Pillsy.DataTransferObjects.Account.AccountDTO;
using Pillsy.DataTransferObjects.Patient.PatientDetailDto;

namespace Pillsy.Mappers
{
    public class PillProfile : Profile
    {
        public PillProfile()
        {
            CreateMap<Pill, Frequency>()
            .ForMember(
                dest => dest.Morning,
                opt => opt.MapFrom(src => src.Morning)
            )
            .ForMember(
                dest => dest.Afternoon,
                opt => opt.MapFrom(src => src.Afternoon)
            )
            .ForMember(
                dest => dest.Evening,
                opt => opt.MapFrom(src => src.Evening)
            );

            CreateMap<Pill, Medication>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.PillName)
            ).ForMember(
                dest => dest.Dosage_per_day,
                opt => opt.MapFrom(src => src.DosagePerDay)
            ).ForMember(
                dest => dest.Quantity_per_dose,
                opt => opt.MapFrom(src => src.QuantityPerDose)
            ).ForMember(
                dest => dest.Total_quantity,
                opt => opt.MapFrom(src => src.Quantity)
            ).ForPath(
                dest => dest.Start_date,
                opt => opt.MapFrom(src => src.Schedule.DateStart)
            ).ForPath(
                dest => dest.End_date,
                opt => opt.MapFrom(src => src.Schedule.DateEnd)
            ).ForPath(
                dest => dest.Frequency.Morning,
                opt => opt.MapFrom(src => src.Morning)
            ).ForPath(
                dest => dest.Frequency.Afternoon,
                opt => opt.MapFrom(src => src.Afternoon)
            ).ForPath(
                dest => dest.Frequency.Evening,
                opt => opt.MapFrom(src => src.Evening)
            );

            CreateMap<Pill, Medication_Records>()
            .ForMember(
                dest => dest.Record_id,
                opt => opt.MapFrom(src => src.PillId)
            );

        }
    }
}
