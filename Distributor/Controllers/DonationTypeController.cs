using System.Collections.Generic;
using System.Threading.Tasks;
using Distributor.Models.DonationType;
using Distributor.Models.DonationType.Commands;
using Distributor.Models.DonationType.Queries;
using MeteorCommon.Database;
using MeteorCommon.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Distributor.Controllers
{
    [ApiController]
    // [Authorize("Admin")]
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
            _lazyDbConnection.TryExecuteDbMessageAsync(new GetDonationTypes());

        [HttpPost]
        public Task<OperationResult<int>> Add(AddDonationType cmd) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(cmd);

        [HttpPut]
        public Task<OperationResult<bool>> Update(UpdateDonationType cmd) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(cmd);

        [HttpDelete("{id}")]
        public Task<OperationResult<bool>> Remove(int id) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(new RemoveDonationType {Id = id});
    }
}