using System.Threading.Tasks;
using Meteor.AspCore.Message.Db;
using Meteor.AspCore.Message.Db.Default;
using Meteor.Database;
using Meteor.Message.Db;

namespace Distributor.Models.Donor.Commands
{
    public class UpdateDonor: DbDefaultUpdateByUserAsync
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string GeoLocation { get; set; }
        public string AvatarUrl { get; set; }
        public string Description { get; set; }

        public UpdateDonor() : base("donor",
                "full_name=@FullName, address=@Address, phone_number=@PhoneNumber," +
            "mobile_number=@MobileNumber, geo_location=@GeoLocation, avatar_url=@AvatarUrl," +
            "description=@Description")
        {
        }
    }
}