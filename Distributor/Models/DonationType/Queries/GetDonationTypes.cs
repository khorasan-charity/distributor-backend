using System.Collections.Generic;
using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;

namespace Distributor.Models.DonationType.Queries
{
    public class GetDonationTypes : DbMessageByUserAsync<IEnumerable<DonationType>>
    {
        protected override Task<IEnumerable<DonationType>> ExecuteMessageAsync()
        {
            return NewSql()
                .Select("donation_type")
                .QueryAsync<DonationType>();
        }
    }
}