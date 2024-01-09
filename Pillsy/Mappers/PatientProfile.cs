using AutoMapper;
using BusinessObject;
using Pillsy.DataTransferObjects.Patient.PatientCreateDTO;
using Pillsy.DataTransferObjects.Patient.PatientDTO;

namespace Pillsy.Mappers
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<PatientDTO, Patient>()
            .ForMember(
                dest => dest.PatientID,
                opt => opt.MapFrom(src => Guid.NewGuid())
            )
            .ForMember(
                dest => dest.FirstName,
                opt => opt.MapFrom(src => src.FirstName)
            )
            .ForMember(
                dest => dest.LastName,
                opt => opt.MapFrom(src => src.LastName)
            )
            .ForMember(
                dest => dest.PhoneNumber,
                opt => opt.MapFrom(src => src.PhoneNumber)
            )
            .ForMember(
                dest => dest.DateOfBirth,
                opt => opt.MapFrom(src => src.DateOfBirth)
            )
            .ForMember(
                dest => dest.Gender,
                opt => opt.MapFrom(src => src.Gender)
            )
            .ForMember(
                dest => dest.Address,
                opt => opt.MapFrom(src => src.Address)
            )
            .ForPath(
                dest => dest.Account.Email,
                opt => opt.MapFrom(src => src.Email)
            )
            .ForPath(
                dest => dest.Account.Password,
                opt => opt.MapFrom(src => src.Password)
            )
            .ForPath(
                dest => dest.Account.Role,
                opt => opt.MapFrom(src => src.Role)
            );
            CreateMap<Patient, PatientDTO>();


            CreateMap<PatientCreateDTO, Patient>()
            .ForMember(
                dest => dest.PatientID,
                opt => opt.MapFrom(src => Guid.NewGuid())
            )
            .ForMember(
                dest => dest.FirstName,
                opt => opt.MapFrom(src => src.FirstName)
            )
            .ForMember(
                dest => dest.LastName,
                opt => opt.MapFrom(src => src.LastName)
            )
            .ForMember(
                dest => dest.PhoneNumber,
                opt => opt.MapFrom(src => src.PhoneNumber)
            )
            .ForMember(
                dest => dest.DateOfBirth,
                opt => opt.MapFrom(src => src.DateOfBirth)
            )
            .ForMember(
                dest => dest.Gender,
                opt => opt.MapFrom(src => src.Gender)
            )
            .ForMember(
                dest => dest.Address,
                opt => opt.MapFrom(src => src.Address)
            )
            .ForPath(
                dest => dest.Account.Email,
                opt => opt.MapFrom(src => src.Email)
            )
            .ForPath(
                dest => dest.Account.Password,
                opt => opt.MapFrom(src => src.Password)
            )
            .ForPath(
                dest => dest.Account.Role,
                opt => opt.MapFrom(src => src.Role)
            )
            .ForMember(
                dest => dest.PaymentId,
                opt => opt.MapFrom(src => src.PaymentId
                ));

        }
    }
}
