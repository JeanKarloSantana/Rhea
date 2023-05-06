using Rhea.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Interfaces.Service
{
    public interface IReservationValidationService
    {
        ValidationResponse ScheduleDateTimeValidation(DateTime starTime, DateTime endTime);
    }
}
