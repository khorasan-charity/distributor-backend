using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.AspCore.Message.Db.Default;
using Meteor.Database;
using Meteor.Message.Db;

namespace Distributor.Models.Donation.Commands
{
    public class RemoveDonation : DbDefaultDeleteByUserAsync
    {
        public int Id { get; set; }

        public RemoveDonation() : base("donation")
        {
        }
    }
}