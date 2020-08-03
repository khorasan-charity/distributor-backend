using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.AspCore.Message.Db.Default;
using Meteor.Database;
using Meteor.Message.Db;

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