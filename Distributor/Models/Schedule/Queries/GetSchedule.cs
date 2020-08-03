using Meteor.AspCore.Message.Db.Default;

namespace Distributor.Models.Schedule.Queries
{
    public class GetSchedule : DbDefaultSelectByUserAsync<Schedule>
    {
        public int Id { get; set; }
        
        public GetSchedule() : base("schedule")
        {
        }
    }
}