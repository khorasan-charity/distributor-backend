using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;
using MeteorCommon.Message.Db.Default;

namespace Distributor.Models.Distributor.Commands
{
    public class RemoveDistributor : DbDefaultDeleteByUserAsync
    {
        public int Id { get; set; }
        
        public RemoveDistributor() : base("distributor")
        {
        }
    }
}