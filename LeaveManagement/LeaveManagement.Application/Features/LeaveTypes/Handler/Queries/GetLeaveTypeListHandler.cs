﻿using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Dtos.LeaveType;
using LeaveManagement.Application.Features.LeaveTypes.Request.Queries;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Handler.Queries
{
    public class GetLeaveTypeListHandler : IRequestHandler<GetLeaveTypeRequest, List<LeaveTypeDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeListHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetAll();

            return _mapper.Map<List<LeaveTypeDto>>(leaveType);
        }
    }
}
