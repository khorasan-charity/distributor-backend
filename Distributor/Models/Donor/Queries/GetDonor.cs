using MeteorCommon.AspCore.Message.Db.Default;

namespace Distributor.Models.Donor.Queries
{
    public class GetDonor : DbDefaultSelectByUserAsync<Donor>
    {
        public int Id { get; set; }
        
        public GetDonor() : base("donor")
        {
        }
    }
}