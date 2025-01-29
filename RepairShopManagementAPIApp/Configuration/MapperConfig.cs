using AutoMapper;
using RepairShopManagementAPIApp.Data;
using RepairShopManagementAPIApp.DTO;

namespace RepairShopManagementAPIApp.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<User, UserPatchDTO>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
