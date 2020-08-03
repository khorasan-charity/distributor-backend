using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.AspCore.Message.Db.Default;
using Meteor.Database;
using Meteor.Message.Db;

namespace Distributor.Models.Donor.Commands
{
    public class RemoveDonor : DbDefaultDeleteByUserAsync
    {
        public int Id { get; set; }
        
        public RemoveDonor() : base("donor")
        {
        }
    }
}