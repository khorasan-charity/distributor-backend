using System.Collections.Generic;
using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;

namespace Distributor.Models.ScheduleType.Queries
{
    public class GetScheduleTypes : DbMessageByUserAsync<IEnumerable<ScheduleType>>
    {
        public GetScheduleTypes(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }

        protected override Task<IEnumerable<ScheduleType>> ExecuteMessageAsync()
        {
            return NewSql()
                .Select("schedule_type")
                .QueryAsync<ScheduleType>();
        }
    }
}