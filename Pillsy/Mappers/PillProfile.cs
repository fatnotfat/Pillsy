using AutoMapper;
using BusinessObject;
using Pillsy.DataTransferObjects.Account.AccountDTO;
using Pillsy.DataTransferObjects.Pill.PillCreateDto;
using Pillsy.DataTransferObjects.Pill.PillCreateWithPrescriptionDto;
using Pillsy.DataTransferObjects.Prescription.PrescriptionCreateDto;

namespace Pillsy.Mappers
{
    public class PillProfile : Profile
    {
        public PillProfile()
        {
           
            CreateMap<Pill, Medication_record>()
            .ForMember(
                dest => dest.Record_id,
                opt => opt.MapFrom(src => src.PillId)
            );


            CreateMap<Medication_record, Pill>()
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
            .ForMember(
                dest => dest.DateStart,
                opt => opt.MapFrom(src => src.Start_date)
            )
            .ForMember(
                dest => dest.DateEnd,
                opt => opt.MapFrom(src => src.End_date)
            )
            ;

            CreateMap<User_data, Pill>()
            .ForMember(
                dest => dest.PrescriptionId,
                opt => opt.MapFrom(src => src.Medication_records_id)
            );

            CreateMap<PillCreateWithPrescriptionDto, Pill>()
            .ForMember(
                dest => dest.PillId,
                opt => opt.MapFrom(src => Guid.NewGuid())
            )
            .ForMember(
                dest => dest.PillName,
                opt => opt.MapFrom(src => src.PillName)
            )
            .ForMember(
                dest => dest.PillDescription,
                opt => opt.MapFrom(src => src.PillDescription)
            )
            .ForMember(
                dest => dest.DosagePerDay,
                opt => opt.MapFrom(src => src.DosagePerDay)
            )
            .ForMember(
                dest => dest.Quantity,
                opt => opt.MapFrom(src => src.Quantity)
            )
            .ForMember(
                dest => dest.QuantityPerDose,
                opt => opt.MapFrom(src => src.QuantityPerDose)
            )
            .ForMember(
                dest => dest.Period,
                opt => opt.MapFrom(src => src.Unit)
            )
            .ForMember(
                dest => dest.Unit,
                opt => opt.MapFrom(src => src.Unit)
            )
            .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => 1)
            )
            .ForMember(
                dest => dest.Index,
                opt => opt.MapFrom(src => 0)
            )
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
            )
            .ForMember(
                dest => dest.PrescriptionId,
                opt => opt.MapFrom(src => src.PrescriptionId)
            )
            .ForMember(
                dest => dest.PillId,
                opt => opt.MapFrom(src => Guid.NewGuid())
            )
            .ForMember(
                dest => dest.DateStart,
                opt => opt.MapFrom(src => src.DateStart)
            )
            .ForMember(
                dest => dest.DateEnd,
                opt => opt.MapFrom(src => src.DateEnd)
            )
            .ForMember(
                dest => dest.CreatedDate,
                opt => opt.MapFrom(src => DateTime.Now)
            )
            ;
        }
    }
}
