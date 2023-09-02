using AutoMapper;

namespace CoreWebApi.Models
{

    //AutoMapper is simple a dependency injection that is used to map one object type to another object type.
    //public class EmpViewModel
    //{
    //    public string Name { get; set; }
    //    public string Email { get; set; }
    //}
    public class EmpViewModel
    {
        public string FName { get; set; }
        public string email { get; set; }
    }

    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            
            CreateMap<Employee,EmpViewModel>()
                .ForMember(dest =>dest.FName,
        opt => opt.MapFrom(src => src.Name))  
                .ForMember(dest => dest.email,
                opt => opt.MapFrom(src =>src.Email)).ReverseMap();  
        }
    }

}
