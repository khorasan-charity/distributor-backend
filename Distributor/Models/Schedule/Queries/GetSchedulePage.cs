using System.Collections.Generic;
using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.Schedule.Queries
{
    public class GetSchedulePage : DbDefaultQueryPageByUserAsync<Schedule>
    {
        public GetSchedulePage() : base("schedule")
        {
        }
    }
}