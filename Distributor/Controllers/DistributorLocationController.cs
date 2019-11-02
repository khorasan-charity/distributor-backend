using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Distributor.Models.Distributor.Commands;
using Distributor.Models.Distributor.Queries;
using Distributor.Models.DistributorLocation;
using Distributor.Models.DistributorLocation.Commands;
using Distributor.Models.DistributorLocation.Queries;
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
    public class DistributorLocationController : ControllerBase
    {
        private readonly ILogger<DistributorLocationController> _logger;
        private readonly LazyDbConnection _lazyDbConnection;

        public DistributorLocationController(ILogger<DistributorLocationController> logger, LazyDbConnection lazyDbConnection)
        {
            _logger = logger;
            _lazyDbConnection = lazyDbConnection;
        }

        [HttpGet]
        public Task<OperationResult<IEnumerable<DistributorLocation>>> Get([FromQuery] int page, [FromQuery] int take) =>
            new GetDistributorLocations(_lazyDbConnection)
            {
                PageNo = page,
                Take = take
            }.TryExecuteAsync();

        [HttpPost]
        public Task<OperationResult<int>> Add(AddDistributorLocation cmd) =>
            cmd.UseLazyDbConnection(_lazyDbConnection).TryExecuteAsync();

        [HttpPut]
        public Task<OperationResult<int>> Update(UpdateDistributorLocation cmd) =>
            cmd.UseLazyDbConnection(_lazyDbConnection).TryExecuteAsync();

        [HttpDelete("{id}")]
        public Task<OperationResult<int>> Remove(int id) =>
            new RemoveDistributorLocation(_lazyDbConnection) {Id = id}.TryExecuteAsync();
    }
}