namespace CheffyExtractData.Domain.DTOs
{
    public class MeetAChefLocationRequest
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string PostalCode { get; set; }
    }
}