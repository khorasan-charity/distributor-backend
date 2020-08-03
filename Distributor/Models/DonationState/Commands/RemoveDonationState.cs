using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.AspCore.Message.Db.Default;
using Meteor.Database;
using Meteor.Message.Db;

namespace Distributor.Models.DonationState.Commands
{
    public class RemoveDonationState : DbDefaultDeleteByUserAsync
    {
        public int Id { get; set; }

        public RemoveDonationState() : base("donation_state")
        {
        }
    }
}