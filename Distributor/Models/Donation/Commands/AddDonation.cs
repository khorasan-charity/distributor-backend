using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.AspCore.Message.Db.Default;
using Meteor.Database;

namespace Distributor.Models.Donation.Commands
{
    public class AddDonation : DbDefaultInsertByUserAsync<int>
    {
        public int DistributorId { get; set; }
        public int DonorId { get; set; }
        public int DonationTypeId { get; set; }
        public int DonationStateId { get; set; }
        public long DonationMoney { get; set; }
        public long ExtraDonationMoney { get; set; }
        public string OtherDonations { get; set; }
        
        public AddDonation() : base("donation",
            "distributor_id, donor_id, donation_type_id, donation_state_id, donation_money," +
            "extra_donation_money, other_donations",
            "@DistributorId, @DonorId, @DonationTypeId, @DonationStateId, @DonationMoney," +
            "@ExtraDonationMoney, @OtherDonations",
            DatabaseType.Sqlite)
        {
        }
    }
}