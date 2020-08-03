using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.AspCore.Message.Db.Default;
using Meteor.Database;
using Meteor.Message.Db;

namespace Distributor.Models.DonationType.Commands
{
    public class RemoveDonationType : DbDefaultDeleteByUserAsync
    {
        public int Id { get; set; }

        public RemoveDonationType() : base("donation_type")
        {
        }
    }
}