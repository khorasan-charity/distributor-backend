﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Distributor.Models.Distributor.Commands;
using Distributor.Models.Distributor.Queries;
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
        public Task<OperationResult<QueryPage<Models.Distributor.Distributor>>> Get([FromQuery] int page, [FromQuery] int take) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(new GetDistributors()
            {
                Page = page,
                Take = take
            });
        
        [HttpGet("search")]
        public Task<OperationResult<QueryPage<Models.Distributor.Distributor>>> Get([FromQuery] SearchDistributors m) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(m);
        
        [HttpGet("{id}")]
        public Task<OperationResult<Models.Distributor.Distributor>> Get(int id) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(new GetDistributor
            {
                Id = id
            });

        [HttpPost]
        public Task<OperationResult<int>> Add(AddDistributor cmd) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(cmd);

        [HttpPut]
        public Task<OperationResult<bool>> Update(UpdateDistributor cmd) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(cmd);

        [HttpDelete("{id}")]
        public Task<OperationResult<bool>> Remove(int id) =>
            _lazyDbConnection.TryExecuteDbMessageAsync(new RemoveDistributor {Id = id});
    }
}