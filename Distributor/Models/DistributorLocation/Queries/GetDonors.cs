using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.AspCore.Message.Db.Default;
using Meteor.Database;
using Meteor.Message.Db;

namespace Distributor.Models.DistributorLocation.Queries
{
    public class GetDistributorLocations : DbDefaultQueryPageByUserAsync<DistributorLocation>
    {
        public GetDistributorLocations() : base("distributor_location")
        {
        }
    }
}