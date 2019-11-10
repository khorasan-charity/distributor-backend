using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;

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