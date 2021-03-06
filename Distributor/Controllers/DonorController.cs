﻿using System.Threading.Tasks;
using Distributor.Models.Donor;
using Distributor.Models.Donor.Commands;
using Distributor.Models.Donor.Queries;
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
        public Task<OperationResult<QueryPage<Donor>>> Get([FromQuery] int page, [FromQuery] int take) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(new GetDonors

            {
                Page = page,
                Take = take
            });
        
        [HttpGet("search")]
        public Task<OperationResult<QueryPage<Donor>>> Get([FromQuery] SearchDonors m) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(m);
        
        [HttpGet("{id}")]
        public Task<OperationResult<Models.Donor.Donor>> Get(int id) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(new GetDonor
            {
                Id = id
            });

        [HttpPost]
        public Task<OperationResult<int>> Add(AddDonor cmd) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(cmd);

        [HttpPut]
        public Task<OperationResult<bool>> Update(UpdateDonor cmd) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(cmd);

        [HttpDelete("{id}")]
        public Task<OperationResult<bool>> Remove(int id) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(new RemoveDonor {Id = id});
    }
}