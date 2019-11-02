using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.Donation.Commands
{
    public class UpdateDonation : DbMessageByUserAsync<int>
    {
        public int Id { get; set; }
        public int DistributorId { get; set; }
        public int DonorId { get; set; }
        public int DonationTypeId { get; set; }
        public int DonationStateId { get; set; }
        public long DonationMoney { get; set; }
        public long ExtraDonationMoney { get; set; }
        public string OtherDonations { get; set; }
        
        public UpdateDonation(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }
        
        public UpdateDonation() : this(null)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Update("donation",
                    "distributor_id=@DistributorId, donor_id=@DonorId, donation_type_id=@DonationTypeId," +
                    "donation_state_id=@DonationStateId, donation_money=@DonationMoney," +
                    "extra_donation_money=@ExtraDonationMoney, other_donations=@OtherDonations")
                .WhereThisId()
                .ExecuteAsync();
        }
    }
}