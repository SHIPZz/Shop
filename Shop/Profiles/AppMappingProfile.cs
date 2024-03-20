using AutoMapper;
using Shop.Commands;
using Shop.Models;

namespace Shop.Profiles;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<DeviceModel, OrderedDeviceModel>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) 
            .ReverseMap();

        CreateMap<DeviceModel, AddOrderedDeviceModelCommand>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) 
            .ReverseMap();

        CreateMap<AddOrderedDeviceModelCommand, OrderedDeviceModel>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) 
            .ReverseMap();
    }
}