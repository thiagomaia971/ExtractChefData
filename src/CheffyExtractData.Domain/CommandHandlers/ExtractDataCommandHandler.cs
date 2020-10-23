using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheffyExtractData.Domain.Commands;
using CheffyExtractData.Domain.Entities;
using CheffyExtractData.Domain.Interfaces.Services;

namespace CheffyExtractData.Domain.CommandHandlers
{
    public class ExtractDataCommandHandler : CommandHandler<ExtractDataCommand, List<Chef>>
    {
        private readonly IExtractDataService _extractDataService;

        public ExtractDataCommandHandler(IExtractDataService extractDataService) 
            => _extractDataService = extractDataService;

        public override List<Chef> Handle(ExtractDataCommand command) 
            => _extractDataService.ExtractData(command).GetAwaiter().GetResult();
    }
}