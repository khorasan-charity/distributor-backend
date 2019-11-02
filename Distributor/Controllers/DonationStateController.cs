using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Distributor.Models.Distributor.Commands;
using Distributor.Models.Distributor.Queries;
using Distributor.Models.DonationState;
using Distributor.Models.DonationState.Commands;
using Distributor.Models.DonationState.Queries;
using MeteorCommon.Database;
using MeteorCommon.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetTopologySuite.Operation.Buffer.Validate;
using Serilog;

namespace Distributor.Controllers
{
    [ApiController]
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
            new GetDonationStates(_lazyDbConnection).TryExecuteAsync();

        [HttpPost]
        public Task<OperationResult<int>> Add(AddDonationState cmd) =>
            cmd.UseLazyDbConnection(_lazyDbConnection).TryExecuteAsync();

        [HttpPut]
        public Task<OperationResult<int>> Update(UpdateDonationState cmd) =>
            cmd.UseLazyDbConnection(_lazyDbConnection).TryExecuteAsync();

        [HttpDelete("{id}")]
        public Task<OperationResult<int>> Remove(int id) =>
            new RemoveDonationState(_lazyDbConnection) {Id = id}.TryExecuteAsync();
    }
}