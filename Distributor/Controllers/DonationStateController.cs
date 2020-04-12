using System.Collections.Generic;
using System.Threading.Tasks;
using Distributor.Models.DonationState;
using Distributor.Models.DonationState.Commands;
using Distributor.Models.DonationState.Queries;
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
    public class DonationStateController : ControllerBase
    {
        private readonly ILogger<DonationStateController> _logger;
        private readonly LazyDbConnection _lazyDbConnection;

        public DonationStateController(ILogger<DonationStateController> logger, LazyDbConnection lazyDbConnection)
        {
            _logger = logger;
            _lazyDbConnection = lazyDbConnection;
        }

        [HttpGet]
        public Task<OperationResult<IEnumerable<DonationState>>> Get() =>
            _lazyDbConnection.TryExecuteDbMessageAsync(new GetDonationStates());

        [HttpPost]
        public Task<OperationResult<int>> Add(AddDonationState cmd) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(cmd);

        [HttpPut]
        public Task<OperationResult<bool>> Update(UpdateDonationState cmd) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(cmd);

        [HttpDelete("{id}")]
        public Task<OperationResult<bool>> Remove(int id) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(new RemoveDonationState {Id = id});
    }
}