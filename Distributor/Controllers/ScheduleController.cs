using System.Collections.Generic;
using System.Threading.Tasks;
using Distributor.Models.Schedule;
using Distributor.Models.Schedule.Commands;
using Distributor.Models.Schedule.Dto;
using Distributor.Models.Schedule.Queries;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;
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
        public Task<OperationResult<QueryPage<ScheduleWithNames>>> Get([FromQuery] GetSchedulePageWithNames m) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(m);
        
        [HttpGet("{id}")]
        public Task<OperationResult<Models.Schedule.Schedule>> Get(int id) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(new GetSchedule
            {
                Id = id
            });

        [HttpPost]
        public Task<OperationResult<int>> Add(AddSchedule cmd) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(cmd);

        [HttpPut]
        public Task<OperationResult<bool>> Update(UpdateSchedule cmd) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(cmd);

        [HttpDelete("{id}")]
        public Task<OperationResult<bool>> Remove(int id) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(new RemoveSchedule {Id = id});
    }
}