using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities.Shared
{
    public class ValidationResponse
    {
        public string Message { get; set; }
        public bool IsValid { get; set; }

        public ValidationResponse SetResponse(ValidationResponse reservationValidation, string message, bool isValid)
        {
            reservationValidation.Message = message;
            reservationValidation.IsValid = isValid;

            return reservationValidation;
        }
    }
}
