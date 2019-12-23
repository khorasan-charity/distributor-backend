using System.Threading.Tasks;
using MeteorCommon.Message.Db;

namespace Distributor.Models.Distributor.Queries
{
    public class SearchDistributors : DbQueryPageAsync<Distributor>
    {
        public string Q { get; set; }
        
        protected override Task<QueryPage<Distributor>> ExecuteMessageAsync()
        {
            Q = Q.Trim();
            
            var where = $"first_name LIKE '%{Q}%' OR last_name LIKE '%{Q}%' OR " +
                        $"national_id LIKE '%{Q}%' OR mobile_number LIKE '%{Q}%' OR " +
                        $"description LIKE '%{Q}%'";
            
            var selectItems = NewSql()
                .Select("distributor")
                .Where(where)
                .OrderBy("last_name");
            var countItems = NewSql()
                .Select("distributor", "COUNT(*)")
                .Where(where);
            
            return this.SelectQueryPageAsync(selectItems, countItems);
        }
    }
}