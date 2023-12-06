using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscriptions;
using OnlineRentCar.Modules.Catalog.Domain.RentalCars.RentalCarSubscription;

namespace OnlineRentCar.Modules.Catalog.Domain.Rentals.RentalSubscription
{
    public class Rental : Entity, IAggregateRoot
    {
        public Guid RentalId { get; set; }
        public Client Client { get; set; }
        public Guid ClientId { get; set; }
        public List<RentalCar> RentalCars { get; set; }
        public DateTime RentalDate { get; set; }

        public Rental()
        {
            RentalId = Guid.NewGuid();
            RentalCars = new List<RentalCar>();
           
        }


        public Rental(Guid clientId, List<Guid> carId,DateTime date)
        {
            RentalId = Guid.NewGuid();
            ClientId = clientId;
            RentalCars = new List<RentalCar>();
           
            foreach (var id in carId)
            {
                RentalCars.Add(new RentalCar(id));
            }
            RentalDate = date;
        }
        public static Rental Create(Guid clientId, List<Guid> carId,DateTime date)
        {

            return new Rental(clientId, carId,date);
        }


    }
}
