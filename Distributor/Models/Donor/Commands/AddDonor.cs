using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.AspCore.Message.Db.Default;
using Meteor.Database;
using Meteor.Message;
using Meteor.Utils;

namespace Distributor.Models.Donor.Commands
{
    public class AddDonor : DbDefaultInsertByUserAsync<int>
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string GeoLocation { get; set; }
        public string AvatarUrl { get; set; }
        public string Description { get; set; }
        
        public AddDonor()
            : base("donor",
                "full_name, address, phone_number, mobile_number, geo_location, avatar_url, description",
                "@FullName, @Address, @PhoneNumber, @MobileNumber, @GeoLocation, @AvatarUrl, @Description",
                DatabaseType.Sqlite)
        {
        }
    }
}