using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;

namespace Distributor.Models.DonationType.Commands
{
    public class AddDonationType : DbDefaultInsertByUserAsync<int>
    {
        public string Name { get; set; }
        
        public AddDonationType()
            : base("donation_type",
            "name",
            "@Name",
            DatabaseType.Sqlite)
        {
        }
    }
}