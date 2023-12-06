using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.BuildingBlocks.Domain;

namespace OnlineRentCar.Modules.Catalog.Application.Rentals.RateCar
{
    public class RateCarCommand : CommandBase<Result>
    {
        public RateCarCommand(Guid carId ,int rate, string text)
        {
            
            CarId = carId;
            Rate = rate;
            Text = text;
        }
       
        public Guid CarId { get; set; }
        public int Rate { get; set; }
        public string Text { get; set; }
    }
}
