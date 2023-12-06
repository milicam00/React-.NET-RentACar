using OnlineLibary.Modules.Catalog.Application.Configuration.Commands;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscriptions;
using OnlineRentCar.Modules.Catalog.Domain.RentalCars.RentalCarSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Rentals.RentalSubscription;

namespace OnlineRentCar.Modules.Catalog.Application.Rentals.AddCommentOwner
{
    public class AddCommentOwnerCommandHandler : ICommandHandler<AddCommentOwnerCommand, Result>
    {
       
        private readonly IRentalCarRepository _rentalCarRepository;
        public AddCommentOwnerCommandHandler(IRentalCarRepository rentalCarRepository)
        {   
            _rentalCarRepository = rentalCarRepository;
        }
        public async Task<Result> Handle(AddCommentOwnerCommand request, CancellationToken cancellationToken)
        {
          
           
            RentalCar rentalCar = await _rentalCarRepository.GetByRentalId(request.RentalId);
            rentalCar.CommentOfOwner = request.Comment;
            _rentalCarRepository.Update(rentalCar);
            return Result.Success(rentalCar);
            
        }
    }
}
