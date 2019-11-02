using System.Collections.Generic;
using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.DistributorLocation.Queries
{
    public class GetDistributorLocations : DbQueryPageByUserAsync<DistributorLocation>
    {
        public GetDistributorLocations(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }

        protected override Task<IEnumerable<DistributorLocation>> ExecuteMessageAsync()
        {
            return NewSql()
                .Select("distributor_location")
                .AddPagination()
                .QueryAsync<DistributorLocation>();
        }
    }
}