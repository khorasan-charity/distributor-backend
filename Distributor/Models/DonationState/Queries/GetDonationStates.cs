using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.Database;
using Meteor.Message.Db;

namespace Distributor.Models.DonationState.Queries
{
    public class GetDonationStates : DbMessageByUserAsync<IEnumerable<DonationState>>
    {
        protected override Task<IEnumerable<DonationState>> ExecuteMessageAsync()
        {
            return NewSql()
                .Select("donation_state")
                .QueryAsync<DonationState>();
        }
    }
}