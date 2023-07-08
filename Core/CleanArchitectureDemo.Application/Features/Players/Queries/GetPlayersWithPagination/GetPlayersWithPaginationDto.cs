using AutoMapper;
using CleanArchitectureDemo.Application.Common.Mappings;
using CleanArchitectureDemo.Domain.Entities;

namespace CleanArchitectureDemo.Application.Features.Players.Queries.GetPlayersWithPagination
{
    public class GetPlayersWithPaginationDto : IMapFrom<Player>
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int ShirtNo { get; init; }
        public int HeightInCm { get; init; }
        public string FacebookUrl { get; init; }
        public string TwitterUrl { get; init; }
        public string InstagramUrl { get; init; }
        public int DisplayOrder { get; init; }
        public void Mapping(Profile profile)
        {
            var c = profile.CreateMap<Player, GetPlayersWithPaginationDto>()
                 //.ForMember(d => d.PhotoUrl, opt => opt.Ignore())
                 .ForMember(d => d.FacebookUrl, opt => opt.NullSubstitute("N/A"))
                 .ForMember(d => d.InstagramUrl, opt => opt.NullSubstitute("N/A"))
                 .ForMember(d => d.TwitterUrl, opt => opt.NullSubstitute("N/A"))
                 .ForMember(d => d.HeightInCm, opt => opt.NullSubstitute(0))
                 .ForMember(d => d.DisplayOrder, opt => opt.NullSubstitute(0));
        }
    }
}
