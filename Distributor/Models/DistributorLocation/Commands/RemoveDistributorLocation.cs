using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.DistributorLocation.Commands
{
    public class RemoveDistributorLocation : DbMessageByUserAsync<int>
    {
        public int Id { get; set; }
        
        public RemoveDistributorLocation(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Delete("distributor_location")
                .WhereThisId()
                .ExecuteAsync();
        }
    }
}