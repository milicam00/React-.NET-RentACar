using OnlineLibary.Modules.Catalog.Application.Configuration.Queries;
using OnlineRentCar.BuildingBlocks.Domain;

namespace OnlineRentCar.Modules.Catalog.Application.Rentals.GetUserRentals
{
    public class GetUserRentalsQuery : QueryBase<Result>
    {
        public GetUserRentalsQuery(string username)
        {
            Username = username;
        }
        public string Username { get; set; }
    }
}
