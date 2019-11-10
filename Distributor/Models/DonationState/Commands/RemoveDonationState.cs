using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

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