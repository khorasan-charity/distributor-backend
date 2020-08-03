using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.Database;

namespace Distributor.Models.ScheduleType.Queries
{
    public class GetScheduleTypes : DbMessageByUserAsync<IEnumerable<ScheduleType>>
    {
        protected override Task<IEnumerable<ScheduleType>> ExecuteMessageAsync()
        {
            return NewSql()
                .Select("schedule_type")
                .QueryAsync<ScheduleType>();
        }
    }
}