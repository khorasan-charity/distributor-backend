using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.AspCore.Message.Db.Default;
using Meteor.Database;

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