using AutoMapper;
using BusinessObject;
using Pillsy.DataTransferObjects.Account.AccountCreateDTO;
using Pillsy.DataTransferObjects.Account.AccountDTO;
using Pillsy.DataTransferObjects.Account.AccountLoginDTO;

namespace Pillsy.Mappers
{
    public class AccountFrofile : Profile
    {
        public AccountFrofile()
        {
            CreateMap<AccountDTO, Account>()
            .ForMember(
                dest => dest.AccountId,
                opt => opt.MapFrom(src => Guid.NewGuid())
            )
            .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => src.Email)
            )
            .ForMember(
                dest => dest.Password,
                opt => opt.MapFrom(src => src.Password)
            )
            .ForMember(
                dest => dest.Role,
                opt => opt.MapFrom(src => src.Role)
            )
            .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => src.Status)
            );


            CreateMap<Account, AccountDTO>()
            .ForMember(
                dest => dest.Role,
                opt => opt.MapFrom(src => src.Role)
            )
            .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => src.Status)
            );


            //create map for login account dto
            CreateMap<AccountLoginDTO, Account>();

            //create map for create account dto
            CreateMap<AccountCreateDTO, Account>()
            .ForMember(
                dest => dest.AccountId,
                opt => opt.MapFrom(src => Guid.NewGuid())
            )
            .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => src.Email)
            )
            .ForMember(
                dest => dest.Password,
                opt => opt.MapFrom(src => src.Password)
            )
            .ForMember(
                dest => dest.Role,
                opt => opt.MapFrom(src => src.Role)
            )
            ;
            CreateMap<Account, AccountCreateDTO>();
        }
    }
}
