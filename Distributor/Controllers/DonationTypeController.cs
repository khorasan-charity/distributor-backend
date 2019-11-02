using System.Collections.Generic;
using System.Threading.Tasks;
using Distributor.Models.DonationType;
using Distributor.Models.DonationType.Commands;
using Distributor.Models.DonationType.Queries;
using MeteorCommon.Database;
using MeteorCommon.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Distributor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationTypeController : ControllerBase
    {
        private readonly ILogger<DonationTypeController> _logger;
        private readonly LazyDbConnection _lazyDbConnection;

        public DonationTypeController(ILogger<DonationTypeController> logger, LazyDbConnection lazyDbConnection)
        {
            _logger = logger;
            _lazyDbConnection = lazyDbConnection;
        }

        [HttpGet]
        public Task<OperationResult<IEnumerable<DonationType>>> Get() =>
            new GetDonationTypes(_lazyDbConnection).TryExecuteAsync();

        [HttpPost]
        public Task<OperationResult<int>> Add(AddDonationType cmd) =>
            cmd.UseLazyDbConnection(_lazyDbConnection).TryExecuteAsync();

        [HttpPut]
        public Task<OperationResult<int>> Update(UpdateDonationType cmd) =>
            cmd.UseLazyDbConnection(_lazyDbConnection).TryExecuteAsync();

        [HttpDelete("{id}")]
        public Task<OperationResult<int>> Remove(int id) =>
            new RemoveDonationType(_lazyDbConnection) {Id = id}.TryExecuteAsync();
    }
}