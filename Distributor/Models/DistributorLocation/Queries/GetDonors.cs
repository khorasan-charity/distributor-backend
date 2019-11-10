using System.Collections.Generic;
using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.DistributorLocation.Queries
{
    public class GetDistributorLocations : DbDefaultQueryPageByUserAsync<DistributorLocation>
    {
        public GetDistributorLocations() : base("distributor_location")
        {
        }
    }
}