using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.Donation.Commands
{
    public class UpdateDonation : DbDefaultUpdateByUserAsync
    {
        public int Id { get; set; }
        public int DistributorId { get; set; }
        public int DonorId { get; set; }
        public int DonationTypeId { get; set; }
        public int DonationStateId { get; set; }
        public long DonationMoney { get; set; }
        public long ExtraDonationMoney { get; set; }
        public string OtherDonations { get; set; }
        
        public UpdateDonation() : base("donation",
            "distributor_id=@DistributorId, donor_id=@DonorId, donation_type_id=@DonationTypeId," +
            "donation_state_id=@DonationStateId, donation_money=@DonationMoney," +
            "extra_donation_money=@ExtraDonationMoney, other_donations=@OtherDonations")
        {
        }
    }
}