using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.AspCore.Message.Db.Default;
using Meteor.Database;
using Meteor.Message.Db;

namespace Distributor.Models.DonationState.Commands
{
    public class UpdateDonationState : DbDefaultUpdateByUserAsync
    {
        public int Id { get; set; }
        public int DonationTypeId { get; set; }
        public string Name { get; set; }
        
        public UpdateDonationState()
            : base("donation_state",
            "donation_type_id=@DonationTypeId, name=@Name")
        {
        }
    }
}