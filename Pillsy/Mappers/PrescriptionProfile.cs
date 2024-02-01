using AutoMapper;
using BusinessObject;
using Microsoft.AspNetCore.Identity;
using Pillsy.DataTransferObjects.Patient.PatientDetailDto;
using Pillsy.DataTransferObjects.Patient.PatientUpdateDto;
using Pillsy.DataTransferObjects.Prescription.PrescriptionCreateDto;

namespace Pillsy.Mappers
{
    public class PrescriptionProfile : Profile
    {
        public PrescriptionProfile()
        {
            CreateMap<PrescriptionCreateDto, Prescription>()
            .ForPath(
                dest => dest.Diagnosis,
                opt => opt.MapFrom(src => src.User_data.Meta_data.Pathological)
            )
            .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => "1")
            )
            .ForMember(
                dest => dest.Index,
                opt => opt.MapFrom(src => "1")
            )
            .ForPath(
                dest => dest.CreatedBy,
                opt => opt.MapFrom(src => src.User_data.Meta_data.User_id)
            )
            .ForPath(
                dest => dest.CreatedDate,
                opt => opt.MapFrom(src => src.User_data.Meta_data.Created_at)
            )
            .ForPath(
                dest => dest.ModifiedBy,
                opt => opt.MapFrom(src => src.User_data.Meta_data.User_id)
            )
            .ForPath(
                dest => dest.LastModifiedDate,
                opt => opt.MapFrom(src => src.User_data.Meta_data.Modified_at)
            )
            .ForPath(
                dest => dest.PrescriptionID,
                opt => opt.MapFrom(src => src.User_data.Medication_records_id)
            )
            .ForPath(
                dest => dest.PatientID,
                opt => opt.MapFrom(src => src.User_data.Meta_data.User_id)
            )
            ;
        }
    }
}
