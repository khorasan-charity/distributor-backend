using System.Collections.Generic;
using System.Threading.Tasks;
using Distributor.Models.ScheduleType;
using Distributor.Models.ScheduleType.Commands;
using Distributor.Models.ScheduleType.Queries;
using MeteorCommon.Database;
using MeteorCommon.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Distributor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleTypeController : ControllerBase
    {
        private readonly ILogger<ScheduleTypeController> _logger;
        private readonly LazyDbConnection _lazyDbConnection;

        public ScheduleTypeController(ILogger<ScheduleTypeController> logger, LazyDbConnection lazyDbConnection)
        {
            _logger = logger;
            _lazyDbConnection = lazyDbConnection;
        }

        [HttpGet]
        public Task<OperationResult<IEnumerable<ScheduleType>>> Get() =>
            _lazyDbConnection.TryExecuteDbMessageAsync(new GetScheduleTypes());

        [HttpPost]
        public Task<OperationResult<int>> Add(AddScheduleType cmd) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(cmd);

        [HttpPut]
        public Task<OperationResult<bool>> Update(UpdateScheduleType cmd) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(cmd);

        [HttpDelete("{id}")]
        public Task<OperationResult<bool>> Remove(int id) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(new RemoveScheduleType {Id = id});
    }
}