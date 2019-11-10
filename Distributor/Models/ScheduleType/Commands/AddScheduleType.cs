using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;

namespace Distributor.Models.ScheduleType.Commands
{
    public class AddScheduleType : DbDefaultInsertByUserAsync<int>
    {
        public string Name { get; set; }
        
        public AddScheduleType() : base("schedule_type",
            "name",
            "@Name",
            DatabaseType.Sqlite)
        {
        }
    }
}