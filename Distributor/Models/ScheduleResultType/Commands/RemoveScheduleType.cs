using Meteor.AspCore.Message.Db.Default;

namespace Distributor.Models.ScheduleResultType.Commands
{
    public class RemoveScheduleResultType : DbDefaultDeleteByUserAsync
    {
        public int Id { get; set; }

        public RemoveScheduleResultType() : base("schedule_result_type")
        {
        }
    }
}