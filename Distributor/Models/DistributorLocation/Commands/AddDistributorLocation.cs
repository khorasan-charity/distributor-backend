using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;

namespace Distributor.Models.DistributorLocation.Commands
{
    public class AddDistributorLocation : DbDefaultInsertByUserAsync<int>
    {
        public int DistributorId { get; set; }
        public int ScheduleId { get; set; }
        public string GeoLocation { get; set; }
        
        public AddDistributorLocation()
            : base("distributor_location",
                "distributor_id, schedule_id, geo_location",
                "@DistributorId, @ScheduleId, @GeoLocation",
                DatabaseType.Sqlite)
        {
        }
    }
}