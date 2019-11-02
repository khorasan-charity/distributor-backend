using System.Collections.Generic;
using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.Distributor.Queries
{
    public class GetDistributors : DbQueryPageByUserAsync<Distributor>
    {
        public GetDistributors(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }

        protected override Task<IEnumerable<Distributor>> ExecuteMessageAsync()
        {
            return NewSql()
                .Select("distributor")
                .AddPagination()
                .QueryAsync<Distributor>();
        }
    }
}