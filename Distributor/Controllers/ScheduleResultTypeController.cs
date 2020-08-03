using System.Collections.Generic;
using System.Threading.Tasks;
using Distributor.Models.ScheduleResultType;
using Distributor.Models.ScheduleResultType.Commands;
using Distributor.Models.ScheduleResultType.Queries;
using Meteor.Database;
using Meteor.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Distributor.Controllers
{
    [ApiController]
    // [Authorize("Admin")]
    [Route("api/[controller]")]
    public class ScheduleResultTypeController : ControllerBase
    {
        private readonly ILogger<ScheduleResultTypeController> _logger;
        private readonly LazyDbConnection _lazyDbConnection;

        public ScheduleResultTypeController(ILogger<ScheduleResultTypeController> logger, LazyDbConnection lazyDbConnection)
        {
            _logger = logger;
            _lazyDbConnection = lazyDbConnection;
        }

        [HttpGet]
        public Task<OperationResult<IEnumerable<ScheduleResultType>>> Get() =>
            _lazyDbConnection.TryExecuteDbMessageAsync(new GetScheduleResultTypes());

        [HttpPost]
        public Task<OperationResult<int>> Add(AddScheduleResultType cmd) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(cmd);

        [HttpPut]
        public Task<OperationResult<bool>> Update(UpdateScheduleResultType cmd) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(cmd);

        [HttpDelete("{id}")]
        public Task<OperationResult<bool>> Remove(int id) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(new RemoveScheduleResultType {Id = id});
    }
}