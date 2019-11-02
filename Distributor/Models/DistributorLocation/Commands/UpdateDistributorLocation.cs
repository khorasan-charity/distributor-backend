using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.DistributorLocation.Commands
{
    public class UpdateDistributorLocation: DbMessageByUserAsync<int>
    {
        public int Id { get; set; }
        public int DistributorId { get; set; }
        public int ScheduleId { get; set; }
        public string GeoLocation { get; set; }

        public UpdateDistributorLocation(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }
        
        public UpdateDistributorLocation() : this(null)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Update("distributor_location",
                    "distributor_id=@DistributorId, schedule_id=@ScheduleId, geo_location=@GeoLocation")
                .WhereThisId()
                .ExecuteAsync();
        }
    }
}