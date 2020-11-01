using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DietShopper.Application.Models;
using DietShopper.Application.Repositories;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Queries.Measures
{
    public class GetMeasuresQuery : Request<IEnumerable<MeasureDto>> { }

    public class GetMeasuresQueryHandler : RequestHandler<GetMeasuresQuery, IEnumerable<MeasureDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMeasuresRepository _measuresRepository;

        public GetMeasuresQueryHandler(IMapper mapper, IMeasuresRepository measuresRepository)
        {
            _mapper = mapper;
            _measuresRepository = measuresRepository;
        }
        
        public override async Task<RequestResult<IEnumerable<MeasureDto>>> Handle(GetMeasuresQuery request, CancellationToken cancellationToken)
        {
            var measures = await _measuresRepository.GetActiveMeasures();

            return request.Success(_mapper.Map<IEnumerable<MeasureDto>>(measures));
        }
    }
}