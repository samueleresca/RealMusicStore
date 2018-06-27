using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Store.API.Models;
using Store.API.Requests;

namespace Store.API.Infrastructure
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CreateVinylRequest, StoreViynl>().ReverseMap();
            CreateMap<UpdateVinylRequest, StoreViynl>().ReverseMap();
        }
    }
}
