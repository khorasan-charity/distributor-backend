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
            new GetScheduleTypes(_lazyDbConnection).TryExecuteAsync();

        [HttpPost]
        public Task<OperationResult<int>> Add(AddScheduleType cmd) =>
            cmd.UseLazyDbConnection(_lazyDbConnection).TryExecuteAsync();

        [HttpPut]
        public Task<OperationResult<int>> Update(UpdateScheduleType cmd) =>
            cmd.UseLazyDbConnection(_lazyDbConnection).TryExecuteAsync();

        [HttpDelete("{id}")]
        public Task<OperationResult<int>> Remove(int id) =>
            new RemoveScheduleType(_lazyDbConnection) {Id = id}.TryExecuteAsync();
    }
}