using System.Collections.Generic;
using System.Threading.Tasks;
using Distributor.Models.Schedule;
using Distributor.Models.Schedule.Commands;
using Distributor.Models.Schedule.Queries;
using MeteorCommon.Database;
using MeteorCommon.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Distributor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly ILogger<ScheduleController> _logger;
        private readonly LazyDbConnection _lazyDbConnection;

        public ScheduleController(ILogger<ScheduleController> logger, LazyDbConnection lazyDbConnection)
        {
            _logger = logger;
            _lazyDbConnection = lazyDbConnection;
        }

        [HttpGet]
        public Task<OperationResult<IEnumerable<Schedule>>> Get([FromQuery] int page, [FromQuery] int take) =>
            new GetSchedules(_lazyDbConnection)
            {
                PageNo = page,
                Take = take
            }.TryExecuteAsync();

        [HttpPost]
        public Task<OperationResult<int>> Add(AddSchedule cmd) =>
            cmd.UseLazyDbConnection(_lazyDbConnection).TryExecuteAsync();

        [HttpPut]
        public Task<OperationResult<int>> Update(UpdateSchedule cmd) =>
            cmd.UseLazyDbConnection(_lazyDbConnection).TryExecuteAsync();

        [HttpDelete("{id}")]
        public Task<OperationResult<int>> Remove(int id) =>
            new RemoveSchedule(_lazyDbConnection) {Id = id}.TryExecuteAsync();
    }
}