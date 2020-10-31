using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DietShopper.Application.Products.Models;
using DietShopper.Application.Products.Repositories;
using DietShopper.Application.Services;
using DietShopper.Common.Requests;
using DietShopper.Domain.Entities;
using DietShopper.Domain.Enums;
using DietShopper.Domain.Exceptions;

namespace DietShopper.Application.Products.Commands.Measures.CreateMeasure
{
    public class CreateMeasureCommandHandler : RequestHandler<CreateMeasureCommand, MeasureDto>
    {
        private readonly IGuid _guid;
        private readonly IMapper _mapper;
        private readonly IMeasuresRepository _measuresRepository;

        public CreateMeasureCommandHandler(IGuid guid,
            IMapper mapper,
            IMeasuresRepository measuresRepository)
        {
            _guid = guid;
            _mapper = mapper;
            _measuresRepository = measuresRepository;
        }

        public override async Task<RequestResult<MeasureDto>> Handle(CreateMeasureCommand request, CancellationToken cancellationToken)
        {
            if (await _measuresRepository.IsNameTaken(request.Name))
                throw new DomainException(ErrorCode.MeasureNameTaken, new {request.Name});
            
            var measure = new Measure(_guid.GetGuid(), request.Name, request.Symbol, request.IsWeight, request.ValueInGrams);
            await _measuresRepository.Save(measure);

            return request.Success(_mapper.Map<MeasureDto>(measure));
        }
    }
}