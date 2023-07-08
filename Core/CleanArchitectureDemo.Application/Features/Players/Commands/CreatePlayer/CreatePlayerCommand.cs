using AutoMapper;
using CleanArchitectureDemo.Application.Common.Mappings;
using CleanArchitectureDemo.Application.IRepositories;
using CleanArchitectureDemo.Domain.Entities;
using CleanArchitectureDemo.Shared;
using MediatR;

namespace CleanArchitectureDemo.Application.Features.Players.Commands.CreatePlayer
{
    /// <summary>
    /// This file contains one record CreatePlayerCommand and CreatePlayerCommandHandler. 
    /// You can separate these two into two separate files but traditionally most developers prefer to 
    /// keep these two together in the same file because it is easier to see both the command and the handler 
    /// in one place and quickly understand what is going on rather than jumping from one file to another file. 
    /// </summary>
    public record CreatePlayerCommand : IRequest<Result<int>>, IMapFrom<Player>
    {
        public string Name { get; set; }
        public int ShirtNo { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime? BirthDate { get; set; }
        /*
         * if any change implement Mapping function and add what needed 
        public void Mapping(Profile profile)
        {
            var c = profile.CreateMap<CreatePlayerCommand, Player>()
                //.ForMember(d => d.PhotoUrl, opt => opt.Ignore())
                 //.ForMember(d => d.ShirtNo, opt => opt.NullSubstitute("N/A"))
                 //.ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
                 .ForMember(d => d.ShirtNo, opt => opt.MapFrom(s => 10));
        }
        */
    }

    internal class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePlayerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreatePlayerCommand command, CancellationToken cancellationToken)
        {
            //var player = new Player()
            //{
            //    Name = command.Name,
            //    ShirtNo = command.ShirtNo,
            //    PhotoUrl = command.PhotoUrl,
            //    BirthDate = command.BirthDate
            //};
            var player = _mapper.Map<Player>(command);

            await _unitOfWork.Repository<Player>().AddAsync(player);
            player.AddDomainEvent(new PlayerCreatedEvent(player));
            await _unitOfWork.Save(cancellationToken);
            return await Result<int>.SuccessAsync(player.Id, "Player Created.");
        }
    }
}
