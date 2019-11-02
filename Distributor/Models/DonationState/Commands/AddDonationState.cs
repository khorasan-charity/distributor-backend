using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;

namespace Distributor.Models.DonationState.Commands
{
    public class AddDonationState : DbMessageByUserAsync<int>
    {
        public int DonationTypeId { get; set; }
        public string Name { get; set; }
        
        public AddDonationState(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }
        
        public AddDonationState() : this(null)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Insert("donation_state",
                    "donation_type_id, name",
                    "@DonationTypeId, @Name")
                .EndStatement()
                .Append("SELECT last_insert_rowid();")
                .ExecuteScalarAsync<int>();
        }
    }
}