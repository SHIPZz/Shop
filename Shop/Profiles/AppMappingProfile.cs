using AutoMapper;
using Shop.Commands;
using Shop.Models;

namespace Shop.Profiles;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<DeviceModel, OrderedDeviceModel>().ReverseMap();
        CreateMap<DeviceModel, AddOrderedDeviceModelCommand>().ReverseMap();
        CreateMap<AddOrderedDeviceModelCommand, OrderedDeviceModel>().ReverseMap();
    }
}