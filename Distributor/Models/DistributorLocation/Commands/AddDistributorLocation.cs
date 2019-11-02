using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;

namespace Distributor.Models.DistributorLocation.Commands
{
    public class AddDistributorLocation : DbMessageByUserAsync<int>
    {
        public int DistributorId { get; set; }
        public int ScheduleId { get; set; }
        public string GeoLocation { get; set; }
        
        public AddDistributorLocation(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }
        public AddDistributorLocation() : this(null)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Insert("distributor_location",
                    "distributor_id, schedule_id, geo_location",
                    "@DistributorId, @ScheduleId, @GeoLocation")
                .EndStatement()
                .Append("SELECT last_insert_rowid();")
                .ExecuteScalarAsync<int>();
        }
    }
}