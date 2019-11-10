using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.Donor.Commands
{
    public class RemoveDonor : DbDefaultDeleteByUserAsync
    {
        public int Id { get; set; }
        
        public RemoveDonor() : base("donor")
        {
        }
    }
}