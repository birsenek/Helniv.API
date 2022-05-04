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
        }
    }
}
