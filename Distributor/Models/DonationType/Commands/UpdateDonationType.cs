using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.AspCore.Message.Db.Default;
using Meteor.Database;
using Meteor.Message.Db;

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