using System.Collections.Generic;
using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;

namespace Distributor.Models.ScheduleResultType.Queries
{
    public class GetScheduleResultTypes : DbMessageByUserAsync<IEnumerable<ScheduleResultType>>
    {
        protected override Task<IEnumerable<ScheduleResultType>> ExecuteMessageAsync()
        {
            return NewSql()
                .Select("schedule_result_type")
                .QueryAsync<ScheduleResultType>();
        }
    }
}