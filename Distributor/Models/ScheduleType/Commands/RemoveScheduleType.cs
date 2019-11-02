using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.ScheduleType.Commands
{
    public class RemoveScheduleType : DbMessageByUserAsync<int>
    {
        public int Id { get; set; }

        public RemoveScheduleType(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Delete("schedule_type")
                .WhereThisId()
                .ExecuteAsync();
        }
    }
}