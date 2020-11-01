using System;
using System.Threading;
using System.Threading.Tasks;
using DietShopper.Application.Repositories;
using DietShopper.Common.Requests;
using DietShopper.Domain.Enums;
using DietShopper.Domain.Exceptions;

namespace DietShopper.Application.Commands.Measures.RemoveMeasure
{
    public class RemoveMeasureCommandHandler : RequestHandler<RemoveMeasureCommand, Guid>
    {
        private readonly IMeasuresRepository _measuresRepository;

        public RemoveMeasureCommandHandler(IMeasuresRepository measuresRepository)
        {
            _measuresRepository = measuresRepository;
        }

        public override async Task<RequestResult<Guid>> Handle(RemoveMeasureCommand request, CancellationToken cancellationToken)
        {
            var measure = await _measuresRepository.GetMeasure(request.MeasureGuid);
            if (measure.IsBaseline)
                throw new DomainException(ErrorCode.CantRemoveBaselineMeasure, new {request.MeasureGuid});

            measure.Deactivate();
            await _measuresRepository.Save(measure);

            return request.Success();
        }
    }
}