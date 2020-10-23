using System.Collections.Generic;
using CheffyExtractData.Domain.Entities;

namespace CheffyExtractData.Domain.DTOs
{
    public class MeetAChefDirectoryResult
    {
        public int Count { get; set; }
        public List<Chef> Listings { get; set; }
    }
}