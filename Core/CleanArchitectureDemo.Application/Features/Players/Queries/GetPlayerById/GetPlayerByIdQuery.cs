﻿using AutoMapper;
using CleanArchitectureDemo.Application.IRepositories;
using CleanArchitectureDemo.Domain.Entities;
using CleanArchitectureDemo.Shared;
using MediatR;

namespace CleanArchitectureDemo.Application.Features.Players.Queries.GetPlayerById
{
    public record GetPlayerByIdQuery : IRequest<Result<GetPlayerByIdDto>>
    {
        public int Id { get; set; }

        public GetPlayerByIdQuery()
        {

        }

        public GetPlayerByIdQuery(int id)
        {
            Id = id;
        }
    }

    internal class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, Result<GetPlayerByIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPlayerByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetPlayerByIdDto>> Handle(GetPlayerByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Player>().GetByIdAsync(query.Id);
            var player = _mapper.Map<GetPlayerByIdDto>(entity);
            return await Result<GetPlayerByIdDto>.SuccessAsync(player);
        }
    }
}
