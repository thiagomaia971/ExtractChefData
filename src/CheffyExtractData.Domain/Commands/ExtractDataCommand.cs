using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheffyExtractData.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CheffyExtractData.Domain.Commands
{
    public class ExtractDataCommand : ICommand<List<Chef>>
    {
        [FromQuery]
        public string State { get; set; }

        [FromQuery]
        public int? Page { get; set; }
    }
}