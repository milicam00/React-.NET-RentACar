using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscriptions;
using OnlineRentCar.Modules.Catalog.Domain.Rentals.RentalSubscription;

namespace OnlineRentCar.Modules.Catalog.Domain.RentalCars.RentalCarSubscription
{
    public class RentalCar : Entity, IAggregateRoot
    {
        public Guid RentalCarId { get; set; }
        public Guid RentalId { get; set; }
        public Guid CarId { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int? RatedRating { get; set; }
        public string? TextualComment { get; set; }
        public bool? Returned { get; set; }
        public int NumberOfDays { get; set; }
        public Rental Rental { get; set; }
        public Car Car { get; set; }
        public double RentalCost { get; set; }
        public string? CommentOfOwner { get; set; }

        public RentalCar()
        {
            RentalCarId = Guid.NewGuid();
            
        }

        public RentalCar(Guid carId)
        {
            CarId = carId;
            Returned = false;
            

        }

        public void RateCar(int rate, string text)
        {

            RatedRating = rate;
            TextualComment = text;
            
           

        }
    }
}
