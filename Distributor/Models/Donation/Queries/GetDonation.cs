using Meteor.AspCore.Message.Db.Default;

namespace Distributor.Models.Donation.Queries
{
    public class GetDonation : DbDefaultSelectByUserAsync<Donation>
    {
        public int Id { get; set; }
        
        public GetDonation() : base("donation")
        {
        }
    }
}