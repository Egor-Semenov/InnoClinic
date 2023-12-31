﻿using Application.DTOs.Offices;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Resourses.Commands.Offices.ChangeStatus
{
    public sealed class ChangeOfficeStatusCommandHandler : IRequestHandler<ChangeOfficeStatusCommand, ChangeOfficeStatusDto>
    {
        private readonly IBaseRepository<Office> _officesRepository;
        private readonly IMapper _mapper;

        public ChangeOfficeStatusCommandHandler(IBaseRepository<Office> officesRepository, IMapper mapper)
        {
            _officesRepository = officesRepository;
            _mapper = mapper;
        }

        public async Task<ChangeOfficeStatusDto> Handle(ChangeOfficeStatusCommand request, CancellationToken cancellationToken)
        {
            var office = await _officesRepository.FindByCondition(x => x.OfficeId == request.OfficeId, false).FirstOrDefaultAsync();

            if (office is null)
            {
                throw new NotFoundException($"Office with id: {request.OfficeId} is not found.");
            }

            if (office.StatusId == (int)request.Status)
            {
                throw new BadRequestException($"Service with id: {request.OfficeId} has {request.Status} status already.");
            }

            office.StatusId = (int)request.Status;
            await _officesRepository.Update(office);

            return _mapper.Map<ChangeOfficeStatusDto>(office);
        }
    }
}
