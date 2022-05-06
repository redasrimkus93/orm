using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using EFCore.BulkExtensions;
using LinqToDb;
using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    [SimpleJob(RunStrategy.Throughput)]
    [MedianColumn]
    public class MergeBenchmark
    {
        [Benchmark]
        public void Merge_With_Linq2Db()
        {
            using (var db = new LinqToDb.Linq2DBDataConnection())
            {

                db.TargetTables.Merge()
                    .Using(db.SourceTables)
                    .On((target, source) => target.Id == source.Id)
                    .InsertWhenNotMatched(source => new TargetTable()
                    {
                        Surname = source.Surname,
                        Ref = source.Ref
                    })
                    .UpdateWhenMatched((target, source) => new TargetTable()
                    {
                        Ref = source.Ref + target.Ref
                    }

                    )
                    .DeleteWhenNotMatchedBySource()
                    .Merge();
            }
        }

        [Benchmark]
        public void Merge_With_EfCore_Bulk_Extension()
        {
            using (var db = new EFCoreWithExtensions.Context())
            {
/*                db.BulkInsertOrUpdateOrDelete<EFCoreWithExtensions.TargetTable>(db.SourceTables.Select(p => new EFCoreWithExtensions.TargetTable()
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
                }).ToList());*/
            }
        }
    }
}
