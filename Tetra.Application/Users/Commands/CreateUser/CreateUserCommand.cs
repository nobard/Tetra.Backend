using AutoMapper;
using MediatR;
using Tetra.Application.Common.Mappings;
using Tetra.Domain;

namespace Tetra.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserVm>, IMapWith<UserDomain>
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Company { get; set; }
        public string INN { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserCommand, UserDomain>()
                .ForMember(command => command.Name,
                    opt => opt.MapFrom(dto => dto.Name))
                .ForMember(command => command.SurName,
                    opt => opt.MapFrom(dto => dto.SurName))
                .ForMember(command => command.Patronymic,
                    opt => opt.MapFrom(dto => dto.Patronymic))
                .ForMember(command => command.PhoneNumber,
                    opt => opt.MapFrom(dto => dto.PhoneNumber))
                .ForMember(command => command.Email,
                    opt => opt.MapFrom(dto => dto.Email))
                .ForMember(command => command.Company,
                    opt => opt.MapFrom(dto => dto.Company))
                .ForMember(command => command.INN,
                    opt => opt.MapFrom(dto => dto.INN));
        }
    }
}
