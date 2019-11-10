using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

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