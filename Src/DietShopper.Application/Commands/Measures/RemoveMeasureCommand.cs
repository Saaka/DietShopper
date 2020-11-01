using System;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Commands.Measures
{
    public class RemoveMeasureCommand : Request
    {
        public Guid MeasureGuid { get; }

        public RemoveMeasureCommand(Guid measureGuid)
        {
            MeasureGuid = measureGuid;
        }
    }
}