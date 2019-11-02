using System.Collections.Generic;
using System.Threading.Tasks;
using Distributor.Models.Distributor.Commands;
using Distributor.Models.Distributor.Queries;
using MeteorCommon.Database;
using MeteorCommon.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Distributor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistributorController : ControllerBase
    {
        private readonly ILogger<DistributorController> _logger;
        private readonly LazyDbConnection _lazyDbConnection;

        public DistributorController(ILogger<DistributorController> logger, LazyDbConnection lazyDbConnection)
        {
            _logger = logger;
            _lazyDbConnection = lazyDbConnection;
        }

        [HttpGet]
        public Task<OperationResult<IEnumerable<Models.Distributor.Distributor>>> Get([FromQuery] int page, [FromQuery] int take) =>
            new GetDistributors(_lazyDbConnection)
            {
                PageNo = page,
                Take = take
            }.TryExecuteAsync();

        [HttpPost]
        public Task<OperationResult<int>> Add(AddDistributor cmd) =>
            cmd.UseLazyDbConnection(_lazyDbConnection).TryExecuteAsync();

        [HttpPut]
        public Task<OperationResult<int>> Update(UpdateDistributor cmd) =>
            cmd.UseLazyDbConnection(_lazyDbConnection).TryExecuteAsync();

        [HttpDelete("{id}")]
        public Task<OperationResult<int>> Remove(int id) =>
            new RemoveDistributor(_lazyDbConnection) {Id = id}.TryExecuteAsync();
    }
}