using System;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Products.Commands
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