using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.AspCore.Message.Db.Default;
using Meteor.Database;
using Meteor.Message.Db;

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