using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DietShopper.Application.Products.Models;
using DietShopper.Application.Products.Repositories;
using DietShopper.Common.Requests;
using DietShopper.Domain.Enums;
using DietShopper.Domain.Exceptions;

namespace DietShopper.Application.Products.Commands.Measures.UpdateMeasure
{
    public class UpdateMeasureCommandHandler : RequestHandler<UpdateMeasureCommand, MeasureDto>
    {
        private readonly IMapper _mapper;
        private readonly IMeasuresRepository _measuresRepository;

        public UpdateMeasureCommandHandler(IMapper mapper,
            IMeasuresRepository measuresRepository)
        {
            _mapper = mapper;
            _measuresRepository = measuresRepository;
        }

        public override async Task<RequestResult<MeasureDto>> Handle(UpdateMeasureCommand request, CancellationToken cancellationToken)
        {
            if (await _measuresRepository.IsNameTaken(request.MeasureGuid, request.Name))
                throw new DomainException(ErrorCode.MeasureNameTaken, new {request.Name});

            var measure = await _measuresRepository.GetMeasure(request.MeasureGuid);
            measure
                .SetName(request.Name)
                .SetSymbol(request.Symbol)
                .SetWeight(request.IsWeight, request.ValueInGrams);

            await _measuresRepository.Save(measure);

            return request.Success(_mapper.Map<MeasureDto>(measure));
        }
    }
}