using System.Threading.Tasks;
using MeteorCommon.Message.Db;

namespace Distributor.Models.Donor.Queries
{
    public class SearchDonors : DbQueryPageAsync<Donor>
    {
        public string Q { get; set; }
        
        protected override Task<QueryPage<Donor>> ExecuteMessageAsync()
        {
            Q = Q.Trim();

            var where = $"full_name LIKE '%{Q}%' OR phone_number LIKE '%{Q}%' OR " +
                        $"mobile_number LIKE '%{Q}%' OR description LIKE '%{Q}%'";

            var selectItems = NewSql()
                .Select("donor")
                .Where(where)
                .OrderBy("full_name");
            var countItems = NewSql()
                .Select("donor", "COUNT(*)")
                .Where(where);
            
            return this.SelectQueryPageAsync(selectItems, countItems);
        }
    }
}