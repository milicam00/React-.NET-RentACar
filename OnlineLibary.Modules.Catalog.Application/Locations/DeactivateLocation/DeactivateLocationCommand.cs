using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.BuildingBlocks.Domain;

namespace OnlineRentCar.Modules.Catalog.Application.Locations.DeactivateLocation
{
    public class DeactivateLocationCommand : CommandBase<Result>
    {
        public DeactivateLocationCommand(Guid locationId,bool isActive)
        {
            
            LocationId = locationId;
            IsActive = isActive;
        }
        public Guid LocationId { get; set; }
        public bool IsActive { get; set; }  
        
    }
}
