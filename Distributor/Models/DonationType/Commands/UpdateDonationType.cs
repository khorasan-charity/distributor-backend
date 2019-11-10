using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.DonationType.Commands
{
    public class UpdateDonationType : DbDefaultUpdateByUserAsync
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public UpdateDonationType() 
            : base("donation_type",
            "name=@Name")
        {
        }
    }
}