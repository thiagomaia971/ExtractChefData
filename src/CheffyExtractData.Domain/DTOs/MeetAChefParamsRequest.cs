namespace CheffyExtractData.Domain.DTOs
{
    public class MeetAChefParamsRequest
    {
        public int Page { get; set; }
        public string Type { get; set; }
        public MeetAChefLocationRequest Location { get; set; }
    }
}