using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.Donor.Commands
{
    public class UpdateDonor: DbMessageByUserAsync<int>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string GeoLocation { get; set; }
        public string AvatarUrl { get; set; }
        public string Description { get; set; }

        public UpdateDonor(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }
        
        public UpdateDonor() : this(null)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Update("donor",
                    "full_name=@FullName, address=@Address, phone_number=@PhoneNumber," +
                    "mobile_number=@MobileNumber, geo_location=@GeoLocation, avatar_url=@AvatarUrl," +
                    "description=@Description")
                .WhereThisId()
                .ExecuteAsync();
        }
    }
}