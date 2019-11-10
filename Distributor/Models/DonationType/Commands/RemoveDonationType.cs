using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

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