using Rhea.Entities.Shared;
using Rhea.Entities.Shared.Messages;
using Rhea.Interfaces.Generic;
using Rhea.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Service
{
    public class FurnitureReservationValidationService : IFurnitureReservationValidationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FurnitureReservationValidationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ValidationResponse ValidateFurniture(List<int> furnitureIds)
        {
            var furnitureValidationResponse = new ValidationResponse();
            
            if (furnitureIds.Count > 10)
                return furnitureValidationResponse.SetResponse(furnitureValidationResponse, FurnitureReservationMessages.MoreThanTenFurniture, false);

            int furnitureCount = _unitOfWork.Furniture.GetAmountOfAvailableFurniture(furnitureIds);
            if (furnitureCount != furnitureIds.Count)
                return furnitureValidationResponse.SetResponse(furnitureValidationResponse, FurnitureReservationMessages.FurnitureNotAvailable, false);
            
            return furnitureValidationResponse.SetResponse(furnitureValidationResponse, FurnitureReservationMessages.ValidFurnitureReservation, true);
        }
    }
}
