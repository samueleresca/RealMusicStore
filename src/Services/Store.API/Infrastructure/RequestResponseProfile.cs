﻿using AutoMapper;
using Store.API.Models;
using Store.API.Requests;
using Store.API.Responses;

namespace Store.API.Infrastructure
{
    public class RequestResponseProfile : Profile
    {
        public RequestResponseProfile()
        {
            CreateMap<CreateVinylRequest, StoreViynl>().ReverseMap();
            CreateMap<UpdateVinylRequest, StoreViynl>().ReverseMap();
            CreateMap<StoreVinylDetailResponseModel, StoreViynl>().ReverseMap();
            CreateMap<StoreVinylListResponseModel, StoreViynl>().ReverseMap();

            CreateMap<StoreArtistListResponseModel, StoreArtist>().ReverseMap();
            CreateMap<CreateArtistRequest, StoreArtist>().ReverseMap();
            CreateMap<UpdateArtistRequest, StoreArtist>().ReverseMap();

            CreateMap<StoreGenreListResponseModel, Genre>().ReverseMap();
            CreateMap<CreateGenreRequest, Genre>().ReverseMap();
            CreateMap<UpdateGenreRequest, Genre>().ReverseMap();
        }
    }
}
