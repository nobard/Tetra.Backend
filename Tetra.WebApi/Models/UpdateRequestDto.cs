using AutoMapper;
using Tetra.Application.Common.Mappings;
using Tetra.Application.Requests.Commands.UpdateRequest;
using Tetra.Domain.Enums;

namespace Tetra.WebApi.Models
{
    public class UpdateRequestDto : IMapWith<UpdateRequestCommand>
    {
        public Guid Id { get; set; }
        public RequestStatus Status { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public int ContainerSize { get; set; }
        public int CargoWeight { get; set; }
        public double Price { get; set; }
        public DateTime DepartureDate { get; set; }
        public string? Comment { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateRequestDto, UpdateRequestCommand>()
                .ForMember(command => command.Id,
                    opt => opt.MapFrom(dto => dto.Id))
                .ForMember(command => command.Status,
                    opt => opt.MapFrom(dto => dto.Status))
                .ForMember(command => command.DepartureCity,
                    opt => opt.MapFrom(dto => dto.DepartureCity))
                .ForMember(command => command.ArrivalCity,
                    opt => opt.MapFrom(dto => dto.ArrivalCity))
                .ForMember(command => command.ContainerSize,
                    opt => opt.MapFrom(dto => dto.ContainerSize))
                .ForMember(command => command.CargoWeight,
                    opt => opt.MapFrom(dto => dto.CargoWeight))
                .ForMember(command => command.Price,
                    opt => opt.MapFrom(dto => dto.Price))
                .ForMember(command => command.DepartureDate,
                    opt => opt.MapFrom(dto => dto.DepartureDate))
                .ForMember(command => command.Comment,
                    opt => opt.MapFrom(dto => dto.Comment));
        }
    }
}
