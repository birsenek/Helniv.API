using AutoMapper;
using Helniv.API.Entities;
using Helniv.API.Models;

namespace Helniv.API.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateCardRequestModel, Card>();

            CreateMap<UpdateCardRequestModel, Card>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        //ignore null/empty properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                    ));
        }
    }
}
