using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheffyExtractData.Domain.Commands;
using CheffyExtractData.Domain.Entities;
using CheffyExtractData.Domain.Interfaces.Repositories;
using CheffyExtractData.Domain.Interfaces.Services;

namespace CheffyExtractData.Domain.Services
{
    public class ExtractDataService : IExtractDataService
    {
        private readonly IMeetAChefRepository _meetAChefRepository;

        public ExtractDataService(IMeetAChefRepository meetAChefRepository) 
            => _meetAChefRepository = meetAChefRepository;

        public async Task<List<Chef>> ExtractData(ExtractDataCommand command)
        {
            if (command.Page.HasValue)
                return (await _meetAChefRepository.ExtractData(command.Page ?? 1, command.State)).Data.Site.Directory.Listings;
            return await ExtractAllPages(command);
        }
        
        private async Task<List<Chef>> ExtractAllPages(ExtractDataCommand command)
        {
            var page = 1;
            var result = await _meetAChefRepository.ExtractData(page, command.State);
            var chefs = result.Data.Site.Directory.Listings;
            while (chefs.Count < result.Data.Site.Directory.Count)
            {
                page++;
                result =  await _meetAChefRepository.ExtractData(page, command.State);
                chefs.AddRange(result.Data.Site.Directory.Listings);
            }

            return chefs;
        }
    }
}