using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.Distributor.Commands
{
    public class UpdateDistributor: DbMessageByUserAsync<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public string MobileNumber { get; set; }
        public string AvatarUrl { get; set; }
        public string Description { get; set; }

        public UpdateDistributor(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }
        public UpdateDistributor() : this(null)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Update("distributor",
                    "first_name=@FirstName, last_name=@LastName, national_id=@NationalId," +
                    "mobile_number=@MobileNumber, avatar_url=@AvatarUrl, description=@Description")
                .WhereThisId()
                .ExecuteAsync();
        }
    }
}