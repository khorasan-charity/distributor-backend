using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.DonationType.Commands
{
    public class UpdateDonationType : DbMessageByUserAsync<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public UpdateDonationType(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }
        
        public UpdateDonationType() : this(null)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Update("donation_type",
                    "name=@Name")
                .WhereThisId()
                .ExecuteAsync();
        }
    }
}