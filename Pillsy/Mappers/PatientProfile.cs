using AutoMapper;
using BusinessObject;
using Pillsy.DataTransferObjects;

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
            .ForMember(
                dest => dest.AccountId,
                opt => opt.MapFrom(src => src.AccountId)
            );
            CreateMap<Patient, PatientDTO>();
        }
    }
}
