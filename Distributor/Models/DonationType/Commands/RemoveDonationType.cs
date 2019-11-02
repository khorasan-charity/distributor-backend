using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.DonationType.Commands
{
    public class RemoveDonationType : DbMessageByUserAsync<int>
    {
        public int Id { get; set; }

        public RemoveDonationType(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Delete("donation_type")
                .WhereThisId()
                .ExecuteAsync();
        }
    }
}