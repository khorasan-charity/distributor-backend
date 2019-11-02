using System.Collections.Generic;
using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.Schedule.Queries
{
    public class GetSchedules : DbQueryPageByUserAsync<Schedule>
    {
        public GetSchedules(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }

        protected override Task<IEnumerable<Schedule>> ExecuteMessageAsync()
        {
            return NewSql()
                .Select("schedule")
                .AddPagination()
                .QueryAsync<Schedule>();
        }
    }
}