using System.Collections.Generic;
using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.Donation.Queries
{
    public class GetDonations : DbQueryPageByUserAsync<Donation>
    {
        public GetDonations(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }

        protected override Task<IEnumerable<Donation>> ExecuteMessageAsync()
        {
            return NewSql()
                .Select("donation")
                .AddPagination()
                .QueryAsync<Donation>();
        }
    }
}