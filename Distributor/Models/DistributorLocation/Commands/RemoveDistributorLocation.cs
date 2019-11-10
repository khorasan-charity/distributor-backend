using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.DistributorLocation.Commands
{
    public class RemoveDistributorLocation : DbDefaultDeleteByUserAsync
    {
        public int Id { get; set; }
        
        public RemoveDistributorLocation() : base("distributor_location")
        {
        }
    }
}