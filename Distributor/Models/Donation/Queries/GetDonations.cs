using System.Collections.Generic;
using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.Donation.Queries
{
    public class GetDonations : DbDefaultQueryPageByUserAsync<Donation>
    {
        public GetDonations() : base("donation")
        {
        }
    }
}