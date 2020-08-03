using Meteor.AspCore.Message.Db.Default;
using Meteor.Database;

namespace Distributor.Models.ScheduleResultType.Commands
{
    public class AddScheduleResultType : DbDefaultInsertByUserAsync<int>
    {
        public string Name { get; set; }
        
        public AddScheduleResultType() : base("schedule_result_type",
            "name",
            "@Name",
            DatabaseType.Sqlite)
        {
        }
    }
}