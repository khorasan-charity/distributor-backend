using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.DonationState.Commands
{
    public class RemoveDonationState : DbMessageByUserAsync<int>
    {
        public int Id { get; set; }

        public RemoveDonationState(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Delete("donation_state")
                .WhereThisId()
                .ExecuteAsync();
        }
    }
}