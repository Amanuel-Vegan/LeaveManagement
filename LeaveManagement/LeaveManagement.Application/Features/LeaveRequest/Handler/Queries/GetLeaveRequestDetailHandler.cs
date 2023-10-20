﻿using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Dtos.LeaveRequest;
using LeaveManagement.Application.Features.LeaveRequest.Request.Queries;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequest.Handler.Queries
{
    public class GetLeaveRequestDetailHandler : IRequestHandler<GetLeaveRequestDetail, LeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestDetailHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetail request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveTypeRepository.GetLeaveTypeDetail(request.Id);

            return _mapper.Map<LeaveRequestDto>(leaveRequest);
        }
    }
}
