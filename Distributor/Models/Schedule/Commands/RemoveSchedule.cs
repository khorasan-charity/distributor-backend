using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.Schedule.Commands
{
    public class RemoveSchedule : DbMessageByUserAsync<int>
    {
        public int Id { get; set; }
        
        public RemoveSchedule(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Delete("schedule")
                .WhereThisId()
                .ExecuteAsync();
        }
    }
}