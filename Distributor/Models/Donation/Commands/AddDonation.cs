using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;

namespace Distributor.Models.Donation.Commands
{
    public class AddDonation : DbMessageByUserAsync<int>
    {
        public int DistributorId { get; set; }
        public int DonorId { get; set; }
        public int DonationTypeId { get; set; }
        public int DonationStateId { get; set; }
        public long DonationMoney { get; set; }
        public long ExtraDonationMoney { get; set; }
        public string OtherDonations { get; set; }
        
        public AddDonation(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }
        
        public AddDonation() : this(null)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Insert("donation",
                    "distributor_id, donor_id, donation_type_id, donation_state_id, donation_money," +
                    "extra_donation_money, other_donations",
                    "@DistributorId, @DonorId, @DonationTypeId, @DonationStateId, @DonationMoney," +
                    "@ExtraDonationMoney, @OtherDonations")
                .EndStatement()
                .Append("SELECT last_insert_rowid();")
                .ExecuteScalarAsync<int>();
        }
    }
}