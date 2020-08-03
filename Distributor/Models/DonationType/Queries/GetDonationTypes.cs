using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.Database;

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