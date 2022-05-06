using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LinqToDB.DataProvider.SqlServer.SqlServerProviderAdapter;

namespace LinqToDb
{
    public class Linq2DBDataConnection : DataConnection
    {
        public Linq2DBDataConnection()
            : base(ProviderName.SqlServer2017, @"Server=.\;Database=Linq2DB;Trusted_Connection=True;Enlist=False;Column Encryption Setting=enabled")
        {
            // create options builder
var builder = new LinqToDbConnectionOptionsBuilder();

// configure connection string
            
        }
        public ITable<SourceTable> SourceTables => this.GetTable<SourceTable>();
        public ITable<TargetTable> TargetTables => this.GetTable<TargetTable>();
    }

    [Table(Name = "Profiles")]
    public class SourceTable
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column]
        public string Ref { get; set; }
        [Column]
        public string Surname { get; set; }

    }

    [Table(Name = "ProfilesExport")]
    public class TargetTable
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column]
        public string Ref { get; set; }
        [Column]
        public string Surname { get; set; }
    }
}
