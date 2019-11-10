using System.Collections.Generic;
using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;
using MeteorCommon.Message.Db.Default;

namespace Distributor.Models.Distributor.Queries
{
    public class GetDistributors : DbDefaultQueryPageByUserAsync<Distributor>
    {
        public GetDistributors() : base("distributor")
        {
        }
    }
}