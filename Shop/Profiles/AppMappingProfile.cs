using AutoMapper;
using Shop.Models;

namespace Shop.Profiles;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<DeviceModel, OrderedDeviceModel>();
    }
}