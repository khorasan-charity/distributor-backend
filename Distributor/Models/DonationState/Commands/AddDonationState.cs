using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.AspCore.Message.Db.Default;
using Meteor.Database;

namespace Distributor.Models.DonationState.Commands
{
    public class AddDonationState : DbDefaultInsertByUserAsync<int>
    {
        public int DonationTypeId { get; set; }
        public string Name { get; set; }

        public AddDonationState(LazyDbConnection lazyDbConnection)
            : base("donation_state",
            "donation_type_id, name",
            "@DonationTypeId, @Name",
            DatabaseType.Sqlite)
        {
        }
    }
}