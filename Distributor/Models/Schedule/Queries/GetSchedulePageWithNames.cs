using System.Collections.Generic;
using System.Threading.Tasks;
using Distributor.Models.Schedule.Dto;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.Schedule.Queries
{
    public class GetSchedulePageWithNames : DbQueryPageAsync<ScheduleWithNames>
    {
        protected override Task<QueryPage<ScheduleWithNames>> ExecuteMessageAsync()
        {
            var selectItems = NewSql()
                .Select("schedule s", "s.*, " +
                                      "dis.first_name || ' ' || dis.last_name distributor_full_name, " +
                                      "don.full_name donor_full_name, " +
                                      "st.name schedule_type_name")
                .LeftJoin("distributor dis", "dis.id=s.distributor_id")
                .LeftJoin("donor don", "don.id=s.donor_id")
                .LeftJoin("schedule_type st", "st.id=s.schedule_type_id")
                .OrderBy("created_at DESC");
            var selectCount = NewSql()
                .Select("schedule", "COUNT(*)");

            return this.SelectQueryPageAsync(selectItems, selectCount);
        }
    }
}