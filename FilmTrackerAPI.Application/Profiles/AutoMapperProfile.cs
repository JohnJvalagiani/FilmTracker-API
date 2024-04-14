using AutoMapper;
using FilmTrackerAPI.Application.Dtos;
using FilmTrackerAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FilmTrackerAPI.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MovieDto, Movie>().ReverseMap();
            CreateMap<Watchlist, WatchListDto>().ReverseMap();
        }
    }
}
