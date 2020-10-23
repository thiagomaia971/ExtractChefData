using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheffyExtractData.Domain.Commands;
using CheffyExtractData.Domain.Entities;

namespace CheffyExtractData.Domain.Interfaces.Services
{
    public interface IExtractDataService : IService
    {
        Task<List<Chef>> ExtractData(ExtractDataCommand command);
    }
}