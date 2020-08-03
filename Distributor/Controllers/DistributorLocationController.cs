using System.Collections.Generic;
using System.Threading.Tasks;
using Distributor.Models.DistributorLocation;
using Distributor.Models.DistributorLocation.Commands;
using Distributor.Models.DistributorLocation.Queries;
using Meteor.Database;
using Meteor.Message.Db;
using Meteor.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Distributor.Controllers
{
    [ApiController]
    // [Authorize("Admin")]
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
        public Task<OperationResult<QueryPage<DistributorLocation>>> Get([FromQuery] int page, [FromQuery] int take) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(new GetDistributorLocations
            {
                Page = page,
                Take = take
            });

        [HttpPost]
        public Task<OperationResult<int>> Add(AddDistributorLocation cmd) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(cmd);

        [HttpPut]
        public Task<OperationResult<bool>> Update(UpdateDistributorLocation cmd) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(cmd);

        [HttpDelete("{id}")]
        public Task<OperationResult<bool>> Remove(int id) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(new RemoveDistributorLocation {Id = id});
    }
}