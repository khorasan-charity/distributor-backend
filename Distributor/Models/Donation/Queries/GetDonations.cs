using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.AspCore.Message.Db.Default;
using Meteor.Database;
using Meteor.Message.Db;

namespace Distributor.Models.Donation.Queries
{
    public class GetDonations : DbDefaultQueryPageByUserAsync<Donation>
    {
        public GetDonations() : base("donation")
        {
        }
    }
}