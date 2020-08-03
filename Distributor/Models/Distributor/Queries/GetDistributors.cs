using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.AspCore.Message.Db.Default;
using Meteor.Database;
using Meteor.Message.Db;
using Meteor.Message.Db.Default;

namespace Distributor.Models.Distributor.Queries
{
    public class GetDistributors : DbDefaultQueryPageByUserAsync<Distributor>
    {
        public GetDistributors() : base("distributor")
        {
        }
    }
}