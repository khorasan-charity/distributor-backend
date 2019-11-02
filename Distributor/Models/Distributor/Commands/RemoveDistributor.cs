using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.Distributor.Commands
{
    public class RemoveDistributor : DbMessageByUserAsync<int>
    {
        public int Id { get; set; }
        
        public RemoveDistributor(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Delete("distributor")
                .WhereThisId()
                .ExecuteAsync();
        }
    }
}