using System.Threading.Tasks;
using MeteorCommon.AspCore.Message.Db;
using MeteorCommon.Database;
using MeteorCommon.Message.Db;

namespace Distributor.Models.Donor.Commands
{
    public class RemoveDonor : DbMessageByUserAsync<int>
    {
        public int Id { get; set; }
        
        public RemoveDonor(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }

        protected override Task<int> ExecuteMessageAsync()
        {
            return NewSql()
                .Delete("donor")
                .WhereThisId()
                .ExecuteAsync();
        }
    }
}