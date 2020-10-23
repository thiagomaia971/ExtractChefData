using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheffyExtractData.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CheffyExtractData.Domain.Commands
{
    public class ExtractDataCommand : ICommand<List<Chef>>
    {
        /// <summary>
        /// State you want to extract
        /// </summary>
        [FromQuery]
        public string State { get; set; }

        /// <summary>
        /// Page number you want to extract.
        /// * If null: will return all pages
        /// </summary>
        [FromQuery]
        public int? Page { get; set; }
    }
}