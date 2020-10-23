using System.ComponentModel;

namespace CheffyExtractData.Domain.Entities
{
    public class Chef
    {
        public ChefAvatar Avatar { get; set; }
        public ChefCity City { get; set; }
        public ChefCountry Country { get; set; }
        public string Description { get; set; }
        public string Featured { get; set; }
        public string LastSeenInWords { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string Path { get; set; }
        public string PayRate { get; set; }
        public string ResponseTimeInWords { get; set; }
        public ChefState State { get; set; }
        public int YearsExperience { get; set; }
        public ChefUser User { get; set; }
    }
}