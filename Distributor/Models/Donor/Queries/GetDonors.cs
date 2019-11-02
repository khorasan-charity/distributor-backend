using System.Collections.Generic;
using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.Donor.Queries
{
    public class GetDonors : DbQueryPageByUserAsync<Donor>
    {
        public GetDonors(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }

        protected override Task<IEnumerable<Donor>> ExecuteMessageAsync()
        {
            return NewSql()
                .Select("donor")
                .AddPagination()
                .QueryAsync<Donor>();
        }
    }
}