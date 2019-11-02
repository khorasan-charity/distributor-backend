using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Distributor.Models.Distributor.Commands;
using Distributor.Models.Distributor.Queries;
using Distributor.Models.Donation;
using Distributor.Models.Donation.Commands;
using Distributor.Models.Donation.Queries;
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
    public class DonationController : ControllerBase
    {
        private readonly ILogger<DonationController> _logger;
        private readonly LazyDbConnection _lazyDbConnection;

        public DonationController(ILogger<DonationController> logger, LazyDbConnection lazyDbConnection)
        {
            _logger = logger;
            _lazyDbConnection = lazyDbConnection;
        }

        [HttpGet]
        public Task<OperationResult<IEnumerable<Donation>>> Get([FromQuery] int page, [FromQuery] int take) =>
            new GetDonations(_lazyDbConnection)
            {
                PageNo = page,
                Take = take
            }.TryExecuteAsync();

        [HttpPost]
        public Task<OperationResult<int>> Add(AddDonation cmd) =>
            cmd.UseLazyDbConnection(_lazyDbConnection).TryExecuteAsync();

        [HttpPut]
        public Task<OperationResult<int>> Update(UpdateDonation cmd) =>
            cmd.UseLazyDbConnection(_lazyDbConnection).TryExecuteAsync();

        [HttpDelete("{id}")]
        public Task<OperationResult<int>> Remove(int id) =>
            new RemoveDonation(_lazyDbConnection) {Id = id}.TryExecuteAsync();
    }
}