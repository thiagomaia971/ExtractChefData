using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheffyExtractData.Domain.DTOs;
using CheffyExtractData.Domain.Entities;

namespace CheffyExtractData.Domain.Interfaces.Repositories
{
    public interface IMeetAChefRepository : IRepository
    {
        Task<MeetAChefResult> ExtractData(int page, string state);
    }
}