using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;

namespace Distributor.Models.DonationType.Commands
{
    public class AddDonationType : DbMessageByUserAsync<int>
    {
        public string Name { get; set; }
        
        public AddDonationType(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }
        
        public AddDonationType() : this(null)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Insert("donation_type",
                    "name",
                    "@Name")
                .EndStatement()
                .Append("SELECT last_insert_rowid();")
                .ExecuteScalarAsync<int>();
        }
    }
}