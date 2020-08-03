using Meteor.AspCore.Message.Db.Default;

namespace Distributor.Models.ScheduleResultType.Commands
{
    public class UpdateScheduleResultType : DbDefaultUpdateByUserAsync
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public UpdateScheduleResultType() : base("schedule_result_type", "name=@Name")
        {
        }
    }
}