using AutoMapper;
using Tetra.Application.Common.Mappings;
using Tetra.Application.Requests.Commands.CreateRequest;

namespace Tetra.WebApi.Models
{
    public class CreateRequestDto : IMapWith<CreateRequestCommand>
    {
        public Guid ClientId { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public int ContainerSize { get; set; }
        public int CargoWeight { get; set; }
        public double Price { get; set; }
        public DateTime DepartureDate { get; set; }
        public string? Comment { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateRequestDto, CreateRequestCommand>()
                .ForMember(com => com.ClientId,
                    opt => opt.MapFrom(dto => dto.ClientId))
                .ForMember(com => com.DepartureCity,
                    opt => opt.MapFrom(dto => dto.DepartureCity))
                .ForMember(com => com.ArrivalCity,
                    opt => opt.MapFrom(dto => dto.ArrivalCity))
                .ForMember(com => com.ContainerSize,
                    opt => opt.MapFrom(dto => dto.ContainerSize))
                .ForMember(com => com.CargoWeight,
                    opt => opt.MapFrom(dto => dto.CargoWeight))
                .ForMember(com => com.Price,
                    opt => opt.MapFrom(dto => dto.Price))
                .ForMember(com => com.DepartureDate,
                    opt => opt.MapFrom(dto => dto.DepartureDate))
                .ForMember(com => com.Comment,
                    opt => opt.MapFrom(dto => dto.Comment));
        }
    }
}
