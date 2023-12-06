namespace OnlineRentCar.Modules.Catalog.Application.Owners.GetPreviousRentalsOwner
{
    public class RentalDto
    {
        public string LocationName { get; set; }
        public Guid CarId { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string VehicleType { get; set; }
        public string TransmissionType {  get; set; }   
        public Guid RentalId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int? RatedRating { get; set; }
        public string? TextualComment { get; set; }
        public int NumberOfDays { get; set; }
        public double RentalCost { get; set; }
        public string UserName { get; set; }
        public string CommentOfOwner { get; set; }
        public Guid ClientId { get;set; }   
    }
}
