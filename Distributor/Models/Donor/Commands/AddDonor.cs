using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message;
using MeteorCommon.Utils;

namespace Distributor.Models.Donor.Commands
{
    public class AddDonor : DbMessageByUserAsync<int>
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string GeoLocation { get; set; }
        public string AvatarUrl { get; set; }
        public string Description { get; set; }
        
        public AddDonor(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }
        
        public AddDonor() : this(null)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Insert("donor",
                    "full_name, address, phone_number, mobile_number, geo_location, avatar_url, description",
                    "@FullName, @Address, @PhoneNumber, @MobileNumber, @GeoLocation, @AvatarUrl, @Description")
                .EndStatement()
                .Append("SELECT last_insert_rowid();")
                .ExecuteScalarAsync<int>();
        }
    }
}