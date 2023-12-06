using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.BuildingBlocks.Domain;

namespace OnlineRentCar.Modules.Catalog.Application.Rentals.AddCommentOwner
{
    public class AddCommentOwnerCommand : CommandBase<Result>
    {
        public AddCommentOwnerCommand(Guid rentalId,string comment) 
        {
           
            RentalId = rentalId;
            Comment = comment;
        }
       
        public Guid RentalId { get; set; }
        public string Comment { get; set; }
    }
}
