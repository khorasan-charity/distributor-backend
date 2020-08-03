using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.AspCore.Message.Db.Default;
using Meteor.Database;
using Meteor.Message.Db;

namespace Distributor.Models.DistributorLocation.Commands
{
    public class RemoveDistributorLocation : DbDefaultDeleteByUserAsync
    {
        public int Id { get; set; }
        
        public RemoveDistributorLocation() : base("distributor_location")
        {
        }
    }
}