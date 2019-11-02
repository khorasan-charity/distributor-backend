using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.DonationState.Commands
{
    public class UpdateDonationState : DbMessageByUserAsync<int>
    {
        public int Id { get; set; }
        public int DonationTypeId { get; set; }
        public string Name { get; set; }
        
        public UpdateDonationState(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }
        
        public UpdateDonationState() : this(null)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Update("donation_state",
                    "donation_type_id=@DonationTypeId, name=@Name")
                .WhereThisId()
                .ExecuteAsync();
        }
    }
}