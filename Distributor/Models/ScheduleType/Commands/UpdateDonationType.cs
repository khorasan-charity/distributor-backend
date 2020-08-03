using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.AspCore.Message.Db.Default;
using Meteor.Database;
using Meteor.Message.Db;

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