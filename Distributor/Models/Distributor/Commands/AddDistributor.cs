using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message;
using MeteorCommon.Utils;

namespace Distributor.Models.Distributor.Commands
{
    public class AddDistributor : DbMessageByUserAsync<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public string AvatarUrl { get; set; }
        public string Description { get; set; }
        
        public AddDistributor(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }
        public AddDistributor() : this(null)
        {
        }

        public override Task<MessageAsync<int>> PreparePropertiesAsync()
        {
            Password = PasswordHash.Hash(Password);
            return Task.FromResult(this as MessageAsync<int>);
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Insert("distributor",
                    "first_name, last_name, national_id, mobile_number, password, avatar_url, description",
                    "@FirstName, @LastName, @NationalId, @MobileNumber, @Password, @AvatarUrl, @Description")
                .EndStatement()
                .Append("SELECT last_insert_rowid();")
                .ExecuteScalarAsync<int>();
        }
    }
}