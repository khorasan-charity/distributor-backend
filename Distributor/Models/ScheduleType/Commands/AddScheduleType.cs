using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.AspCore.Message.Db.Default;
using Meteor.Database;

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