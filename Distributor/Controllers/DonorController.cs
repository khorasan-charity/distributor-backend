using System.Collections.Generic;
using System.Threading.Tasks;
using Distributor.Models.Donor;
using Distributor.Models.Donor.Commands;
using Distributor.Models.Donor.Queries;
using MeteorCommon.Database;
using MeteorCommon.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Distributor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonorController : ControllerBase
    {
        private readonly ILogger<DonorController> _logger;
        private readonly LazyDbConnection _lazyDbConnection;

        public DonorController(ILogger<DonorController> logger, LazyDbConnection lazyDbConnection)
        {
            _logger = logger;
            _lazyDbConnection = lazyDbConnection;
        }

        [HttpGet]
        public Task<OperationResult<IEnumerable<Donor>>> Get([FromQuery] int page, [FromQuery] int take) =>
            new GetDonors(_lazyDbConnection)
            {
                PageNo = page,
                Take = take
            }.TryExecuteAsync();

        [HttpPost]
        public Task<OperationResult<int>> Add(AddDonor cmd) =>
            cmd.UseLazyDbConnection(_lazyDbConnection).TryExecuteAsync();

        [HttpPut]
        public Task<OperationResult<int>> Update(UpdateDonor cmd) =>
            cmd.UseLazyDbConnection(_lazyDbConnection).TryExecuteAsync();

        [HttpDelete("{id}")]
        public Task<OperationResult<int>> Remove(int id) =>
            new RemoveDonor(_lazyDbConnection) {Id = id}.TryExecuteAsync();
    }
}