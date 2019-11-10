using System.Collections.Generic;
using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.Schedule.Queries
{
    public class GetSchedules : DbDefaultQueryPageByUserAsync<Schedule>
    {
        public GetSchedules() : base("schedule")
        {
        }
    }
}