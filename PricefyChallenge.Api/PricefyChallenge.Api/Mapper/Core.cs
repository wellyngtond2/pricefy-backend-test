using AutoMapper;
using PricefyChallenge.Api.Responses;
using PricefyChallenge.Core.Entities;

namespace PricefyChallenge.Api.Mapper
{
    public sealed class Core : Profile
    {
        public Core()
        {
            CreateMap<Movie, MovieResponse>();
        }
    }
}
