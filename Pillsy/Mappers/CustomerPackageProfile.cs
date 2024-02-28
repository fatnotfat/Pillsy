using AutoMapper;
using BusinessObject;
using Pillsy.DataTransferObjects.Account.AccountCreateDTO;
using Pillsy.DataTransferObjects.Account.AccountDTO;
using Pillsy.DataTransferObjects.Account.AccountLoginDTO;
using Pillsy.DataTransferObjects.CustomerPackageDto;

namespace Pillsy.Mappers
{
    public class CustomerPackageProfile : Profile
    {
        public CustomerPackageProfile()
        {
            CreateMap<CustomerPackageDto, CustomerPackage>()
            .ForMember(
                dest => dest.CustomerPackageId,
                opt => opt.MapFrom(src => Guid.NewGuid())
            )
            .ForMember(
                dest => dest.CustomerPackageName,
                opt => opt.MapFrom(src => src.CustomerPackageName)
            )
            .ForMember(
                dest => dest.NumberScan,
                opt => opt.MapFrom(src => src.NumberScan)
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
                dest => dest.AllowPillHistory,
                opt => opt.MapFrom(src => src.AllowPillHistory)
            )
            .ForMember(
                dest => dest.PatientId,
                opt => opt.MapFrom(src => src.PatientId)
            )
            .ForMember(
                dest => dest.CreatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow)
            )
            .ForMember(
                dest => dest.CreatedBy,
                opt => opt.MapFrom(src => src.PatientId)
            )
            .ForMember(
                dest => dest.LastModifiedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow)
            )
            .ForMember(
                dest => dest.ModifiedBy,
                opt => opt.MapFrom(src => src.PatientId)
            );
        }
    }
}
