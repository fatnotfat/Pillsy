using AutoMapper;
using BusinessObject;
using Pillsy.DataTransferObjects.Account.AccountDTO;
using Pillsy.DataTransferObjects.Pill.PillCreateDto;
using Pillsy.DataTransferObjects.Prescription.PrescriptionCreateDto;

namespace Pillsy.Mappers
{
    public class PillProfile : Profile
    {
        public PillProfile()
        {
           
            CreateMap<Pill, Medication_records>()
            .ForMember(
                dest => dest.Record_id,
                opt => opt.MapFrom(src => src.PillId)
            );


            CreateMap<Medication_records, Pill>()
            .ForPath(
                dest => dest.PillId,
                opt => opt.MapFrom(src => src.Record_id)
            )
            .ForMember(
                dest => dest.PillName,
                opt => opt.MapFrom(src => src.Name)
            )
            .ForMember(
                dest => dest.PillDescription,
                opt => opt.MapFrom(src => src.Name)
            )
            .ForMember(
                dest => dest.DosagePerDay,
                opt => opt.MapFrom(src => src.Dosage_per_day)
            )
            .ForMember(
                dest => dest.Quantity,
                opt => opt.MapFrom(src => src.Total_quantity)
            )
            .ForMember(
                dest => dest.QuantityPerDose,
                opt => opt.MapFrom(src => src.Quantity_per_dose)
            )
            .ForMember(
                dest => dest.Unit,
                opt => opt.MapFrom(src => src.Unit)
            )
            .ForMember(
                dest => dest.Morning,
                opt => opt.MapFrom(src => src.Frequency_morning)
            )
            .ForMember(
                dest => dest.Afternoon,
                opt => opt.MapFrom(src => src.Frequency_afternoon)
            )
            .ForMember(
                dest => dest.Evening,
                opt => opt.MapFrom(src => src.Frequency_evening)
            )
            ;

            CreateMap<User_data, Pill>()
            .ForMember(
                dest => dest.PrescriptionId,
                opt => opt.MapFrom(src => src.Medication_records_id)
            );
        }
    }
}
