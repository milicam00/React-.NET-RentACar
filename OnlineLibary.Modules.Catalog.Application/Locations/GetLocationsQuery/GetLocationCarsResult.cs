using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRentCar.Modules.Catalog.Application.Locations.GetLocationsQuery
{
    public class GetLocationCarsResult
    {
        public Guid LocationId { get; set; }  
        public string LocationName { get; set; }
        public List<CarDto> Cars { get; set; }

    }
}
