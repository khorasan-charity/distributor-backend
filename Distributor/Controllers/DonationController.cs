using System.Collections.Generic;
using System.Threading.Tasks;
using Distributor.Models.Donation;
using Distributor.Models.Donation.Commands;
using Distributor.Models.Donation.Queries;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;
using MeteorCommon.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Distributor.Controllers
{
    [ApiController]
    // [Authorize("Admin")]
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
        public Task<OperationResult<QueryPage<Donation>>> Get([FromQuery] int page, [FromQuery] int take) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(new GetDonations
            {
                Page = page,
                Take = take
            });
        
        [HttpGet("{id}")]
        public Task<OperationResult<Models.Donation.Donation>> Get(int id) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(new GetDonation
            {
                Id = id
            });

        [HttpPost]
        public Task<OperationResult<int>> Add(AddDonation cmd) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(cmd);

        [HttpPut]
        public Task<OperationResult<bool>> Update(UpdateDonation cmd) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(cmd);

        [HttpDelete("{id}")]
        public Task<OperationResult<bool>> Remove(int id) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(new RemoveDonation {Id = id});
    }
}