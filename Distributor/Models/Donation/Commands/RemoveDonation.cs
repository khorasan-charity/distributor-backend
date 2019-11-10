using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

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