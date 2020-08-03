using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.AspCore.Message.Db.Default;
using Meteor.Database;
using Meteor.Message.Db;

namespace Distributor.Models.Donor.Queries
{
    public class GetDonors : DbDefaultQueryPageByUserAsync<Donor>
    {
        public GetDonors() : base("donor")
        {
        }
    }
}