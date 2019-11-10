using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.ScheduleType.Commands
{
    public class RemoveScheduleType : DbDefaultDeleteByUserAsync
    {
        public int Id { get; set; }

        public RemoveScheduleType() : base("schedule_type")
        {
        }
    }
}