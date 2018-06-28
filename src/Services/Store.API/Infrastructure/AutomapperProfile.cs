using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Store.API.Models;
using Store.API.Requests;
using Store.API.Responses;

namespace Store.API.Infrastructure
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CreateVinylRequest, StoreViynl>().ReverseMap();
            CreateMap<UpdateVinylRequest, StoreViynl>().ReverseMap();
            CreateMap<StoreVinylDetailResponseModel, StoreViynl>().ReverseMap();
            CreateMap<StoreVinylListResponseModel, StoreViynl>().ReverseMap();
        }
    }
}
