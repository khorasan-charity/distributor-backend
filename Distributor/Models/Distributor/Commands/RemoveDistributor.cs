using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.AspCore.Message.Db.Default;
using Meteor.Database;
using Meteor.Message.Db;
using Meteor.Message.Db.Default;

namespace Distributor.Models.Distributor.Commands
{
    public class RemoveDistributor : DbDefaultDeleteByUserAsync
    {
        public int Id { get; set; }
        
        public RemoveDistributor() : base("distributor")
        {
        }
    }
}