using System.Threading.Tasks;
using MeteorCommon.Database;
using MeteorCommon.Message;
using MeteorCommon.Message.Db;

namespace Distributor.Messages.Database
{
    public class CreateDatabase : DbMessageAsync<bool>
    {
        public CreateDatabase(LazyDbConnection lazyDbConnection) : base(lazyDbConnection)
        {
        }
        
        protected override async Task<bool> ExecuteMessageAsync()
        {
            await ExecuteAsync(@"
CREATE TABLE IF NOT EXISTS distributor (
    id integer NOT NULL PRIMARY KEY,
    first_name text NOT NULL,
    last_name text NOT NULL,
    national_id text NOT NULL,
    mobile_number text NOT NULL,
    password text NOT NULL,
    avatar_url text NULL,
    description text NULL,
    created_at text NOT NULL DEFAULT CURRENT_TIMESTAMP
);
CREATE TABLE IF NOT EXISTS donor (
    id integer NOT NULL PRIMARY KEY,
    full_name text NOT NULL,
    address text NOT NULL,
    phone_number text NOT NULL,
    mobile_number text NOT NULL,
    geo_point text NULL,
    avatar_url text NULL,
    description text NULL,
    created_at text NOT NULL DEFAULT CURRENT_TIMESTAMP
);
CREATE TABLE IF NOT EXISTS donation_type (
    id integer NOT NULL PRIMARY KEY,
    name text NOT NULL UNIQUE,
    created_at text NOT NULL DEFAULT CURRENT_TIMESTAMP
);
CREATE TABLE IF NOT EXISTS donation_state (
    id integer NOT NULL PRIMARY KEY,
    donation_type integer REFERENCES donation_type(id) ON DELETE RESTRICT,
    name text NOT NULL,
    created_at text NOT NULL DEFAULT CURRENT_TIMESTAMP
);
CREATE TABLE IF NOT EXISTS donation (
    id integer NOT NULL PRIMARY KEY,
    distributor_id integer REFERENCES distributor(id) ON DELETE RESTRICT,
    donor_id integer REFERENCES donor(id) ON DELETE RESTRICT,
    donation_type_id integer REFERENCES donation_type(id) ON DELETE RESTRICT,
    donation_state_id integer REFERENCES donation_state(id) ON DELETE RESTRICT,
    donation_money integer NOT NULL,
    extra_donation_money integer NOT NULL,
    other_donations text NULL,
    created_at text NOT NULL DEFAULT CURRENT_TIMESTAMP
);
CREATE TABLE IF NOT EXISTS mission_type (
    id integer NOT NULL PRIMARY KEY,
    name text NOT NULL,
    created_at text NOT NULL DEFAULT CURRENT_TIMESTAMP
);
CREATE TABLE IF NOT EXISTS schedule (
    id integer NOT NULL PRIMARY KEY,
    distributor_id integer REFERENCES distributor(id) ON DELETE RESTRICT,
    donor_id integer REFERENCES distributor(id) ON DELETE RESTRICT,
    mission_type_id integer REFERENCES mission_type(id) ON DELETE RESTRICT,
    due_at integer NOT NULL,
    done_at integer NOT NULL,
    description text NULL,
    created_at text NOT NULL DEFAULT CURRENT_TIMESTAMP
);
CREATE TABLE IF NOT EXISTS mission (
    id integer NOT NULL PRIMARY KEY,
    distributor_id integer REFERENCES distributor(id) ON DELETE RESTRICT,
    schedule_id integer REFERENCES schedule(id) ON DELETE RESTRICT,
    geo_point text NOT NULL,
    created_at integer NOT NULL
);
");
            return true;
        }
    }
}