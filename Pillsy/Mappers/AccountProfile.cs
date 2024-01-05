﻿using AutoMapper;
using Pillsy.DataTransferObjects;
using BusinessObject;

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
        }
    }
}
