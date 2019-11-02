using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.Donation.Commands
{
    public class RemoveDonation : DbMessageByUserAsync<int>
    {
        public int Id { get; set; }

        public RemoveDonation(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Delete("donation")
                .WhereThisId()
                .ExecuteAsync();
        }
    }
}