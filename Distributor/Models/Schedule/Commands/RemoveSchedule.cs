using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.Schedule.Commands
{
    public class RemoveSchedule : DbDefaultDeleteByUserAsync
    {
        public int Id { get; set; }
        
        public RemoveSchedule() : base("schedule")
        {
        }
    }
}