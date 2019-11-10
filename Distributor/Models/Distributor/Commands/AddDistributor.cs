using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.AspCore.Message.Db.Default;
using MeteorCommon.Database;
using MeteorCommon.Message;
using MeteorCommon.Message.Db.Default;
using MeteorCommon.Utils;

namespace Distributor.Models.Distributor.Commands
{
    public class AddDistributor : DbDefaultInsertByUserAsync<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public string AvatarUrl { get; set; }
        public string Description { get; set; }
        
        public AddDistributor()
            : base("distributor",
                "first_name, last_name, national_id, mobile_number, password, avatar_url, description",
                "@FirstName, @LastName, @NationalId, @MobileNumber, @Password, @AvatarUrl, @Description",
                DatabaseType.Sqlite)
        {
        }

        public override Task<MessageAsync<int>> PreparePropertiesAsync()
        {
            Password = PasswordHash.Hash(Password);
            return Task.FromResult(this as MessageAsync<int>);
        }
    }
}