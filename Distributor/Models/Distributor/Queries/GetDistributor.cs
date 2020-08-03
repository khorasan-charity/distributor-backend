using Meteor.AspCore.Message.Db.Default;

namespace Distributor.Models.Distributor.Queries
{
    public class GetDistributor : DbDefaultSelectByUserAsync<Distributor>
    {
        public int Id { get; set; }
        public GetDistributor() : base("distributor")
        {
        }
    }
}