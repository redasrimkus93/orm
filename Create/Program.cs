// See https://aka.ms/new-console-template for more information

using LinqToDb;
using LinqToDB.Configuration;
using LinqToDB.Data;
using LinqToDB.DataProvider.SqlServer;
using System.Data.SqlClient;

/*CreateEfCoreDb();

static void CreateEfCoreDb()
{
    using var context = new EFCoreDbContex();
    bool isEfCoreCreated = context.Database.CanConnect();

    if (!isEfCoreCreated)
    {
        Console.WriteLine($"Creating EF Core Database on {context.Database.GetDbConnection().ConnectionString}");
        context.Database.EnsureCreated();
    }
    else
    {
        Console.WriteLine("Skipping creation of Ef Core database. It already exists.");
    }

    Console.WriteLine("EF Core complete.");
}*/

/*Bulk_Copy_With_EfCore_Linq2Db_Extension();

static void Bulk_Copy_With_EfCore_Linq2Db_Extension()
{

    using (var db = new EFCoreLinq2DbExtension.EfCoreLinq2DbExtensionContext())
    {
        //db.Profiles.ToLinqToDBTable();
        var query =
        from p in db.ProfilesExport
        select p;
        query.AsCte().Merge().Using(db.Profiles.Select(p => new ProfileExport()
        {
            Id = p.Id,
            Ref = p.Ref,
            Country = p.Country,
            Email = p.Email,
            Forename = p.Forename,
            DateOfBirth = p.DateOfBirth,
            Salutation = p.Salutation,
            Surname = p.Surname,
            TelNo = p.TelNo
        })).OnTargetKey()
    .InsertWhenNotMatched() // insert new records
    .UpdateWhenMatched() // update known records
    .DeleteWhenNotMatchedBySource() // delete others
    .Merge();
    }
}*/

/*db.ProfilesExport
    .Merge()
        .Using(db.Profiles.Select(p => new ProfileExport()
        {
            Id = p.Id,
            Ref = p.Ref,
            Country = p.Country,
            Email = p.Email,
            Forename = p.Forename,
            DateOfBirth = p.DateOfBirth,
            Salutation = p.Salutation,
            Surname = p.Surname,
            TelNo = p.TelNo
        })) // use data from temp table
    .OnTargetKey()
    .InsertWhenNotMatched() // insert new records
    .UpdateWhenMatched() // update known records
    .DeleteWhenNotMatchedBySource() // delete others
    .Merge();*/

/*Bulk_Copy_With_Linq2Db();

static void Bulk_Copy_With_Linq2Db()
{
    using (var db = new LinqToDb.Linq2DBSqlDataConnection())
    {
        var profiles = new List<LinqToDb.Profile>();
        for (int i = 0; i < 90000; i++)
        {
            profiles.Add(new LinqToDb.Profile()
            {
                Ref = "Ref " + i,
                Country = "Country " + i,
                DateOfBirth = DateTime.Now,
                Email = "Email " + i,
                Forename = "Forename " + i,
                Salutation = "Salutation " + i,
                Surname = "Surname " + i,
                TelNo = "TelNo " + i
            });
        }
        db.BulkCopy(profiles);
    }
}*/










/*Bulk_Copy_With_Linq2Db();

static void Bulk_Copy_With_Linq2Db()
{
    using (var db = new EFCoreWithExtensions.EFCoreWithBulkExtensionContext())
    {
        var profiles = new List<EFCoreWithExtensions.Profile>();
        for (int i = 0; i < 90000; i++)
        {
            profiles.Add(new EFCoreWithExtensions.Profile()
            {
                Ref = "Ref " + i,
                Country = "Country " + i,
                DateOfBirth = DateTime.Now,
                Email = "Email " + i,
                Forename = "Forename " + i,
                Salutation = "Salutation " + i,
                Surname = "Surname " + i,
                TelNo = "TelNo " + i
            });
        }
        db.BulkCopy(profiles);
    }
}*/






/*Bulk_Copy_With_Linq2Db();

static void Bulk_Copy_With_Linq2Db()
{
    using (var db = new Linq2DBDataConnection())
    {
        var options = new BulkCopyOptions();

        var sources = db.SourceTables.ToList();
        foreach (var item in sources)
        {
            Console.WriteLine(item.Surname);
            Console.WriteLine(item.Ref);
        }
    }
}*/

var builder = new LinqToDbConnectionOptionsBuilder();
builder.UseConnectionFactory(
    SqlServerTools.GetDataProvider(
        SqlServerVersion.v2017,
        SqlServerProvider.MicrosoftDataSqlClient),
    () =>
    {
        var cn = new SqlConnection(@"Server=.\;Database=Linq2DB;Trusted_Connection=True;Enlist=False;Column Encryption Setting=enabled");
        return cn;
    });

// configure connection string
//builder.UseSqlServer(@"Server=.\;Database=Linq2DB;Trusted_Connection=True;Enlist=False;Column Encryption Setting=enabled");

// or using custom connection factory


// pass configured options to data connection constructor
var dc = new DataConnection(builder.Build());

var table = dc.GetTable<SourceTable>();
var list = table.ToList();
Console.WriteLine();
/*foreach (var item in tablelist)
{
    Console.WriteLine(item.Ref);
    Console.WriteLine(item.Surname);
}*/
/*foreach (var item in sources)
{
    Console.WriteLine(item.Surname);
    Console.WriteLine(item.Ref);
}*/