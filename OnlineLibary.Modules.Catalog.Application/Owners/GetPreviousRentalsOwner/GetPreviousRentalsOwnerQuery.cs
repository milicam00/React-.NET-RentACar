using OnlineLibary.Modules.Catalog.Application.Configuration.Queries;
using OnlineRentCar.BuildingBlocks.Domain;

namespace OnlineRentCar.Modules.Catalog.Application.Owners.GetPreviousRentalsOwner
{
    public class GetPreviousRentalsOwnerQuery : QueryBase<Result>
    {
        public GetPreviousRentalsOwnerQuery(string ownerUsername)
        {
            OwnerUsername = ownerUsername; 
        }
        public string OwnerUsername { get; set; }
    }
}
