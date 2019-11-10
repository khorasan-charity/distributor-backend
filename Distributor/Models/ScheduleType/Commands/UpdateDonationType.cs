using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.ScheduleType.Commands
{
    public class UpdateScheduleType : DbDefaultUpdateByUserAsync
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public UpdateScheduleType() : base("schedule_type", "name=@Name")
        {
        }
    }
}