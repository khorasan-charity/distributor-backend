using System.Collections.Generic;
using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.DonationState.Queries
{
    public class GetDonationStates : DbMessageByUserAsync<IEnumerable<DonationState>>
    {
        public GetDonationStates(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }

        protected override Task<IEnumerable<DonationState>> ExecuteMessageAsync()
        {
            return NewSql()
                .Select("donation_state")
                .QueryAsync<DonationState>();
        }
    }
}