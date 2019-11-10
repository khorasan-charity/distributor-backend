using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.DistributorLocation.Commands
{
    public class UpdateDistributorLocation: DbDefaultUpdateByUserAsync
    {
        public int Id { get; set; }
        public int DistributorId { get; set; }
        public int ScheduleId { get; set; }
        public string GeoLocation { get; set; }

        public UpdateDistributorLocation() : base("distributor_location",
            "distributor_id=@DistributorId, schedule_id=@ScheduleId, geo_location=@GeoLocation")
        {
        }
    }
}