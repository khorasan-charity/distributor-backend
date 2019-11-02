using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;

namespace Distributor.Models.ScheduleType.Commands
{
    public class AddScheduleType : DbMessageByUserAsync<int>
    {
        public string Name { get; set; }
        
        public AddScheduleType(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }
        
        public AddScheduleType() : this(null)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Insert("schedule_type",
                    "name",
                    "@Name")
                .EndStatement()
                .Append("SELECT last_insert_rowid();")
                .ExecuteScalarAsync<int>();
        }
    }
}