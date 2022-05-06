using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using LinqToDB.Data;
using LinqToDB.EntityFrameworkCore;
using EFCore.BulkExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreWithExtensions;
using LinqToDb;

namespace Benchmark
{
    [SimpleJob(RunStrategy.Throughput, launchCount: 1, warmupCount: 0, targetCount: 0)]
    [MedianColumn]
    public class BulkCopyBenchmark
    {
        const int N = 100000;

        [Benchmark]
        public void Bulk_Copy_With_Linq2Db()
        {
            using (var db = new Linq2DBDataConnection())
            {
                var profiles = new List<LinqToDb.SourceTable>();
                for (int i = 0; i < N; i++)
                {
                    profiles.Add(new LinqToDb.SourceTable()
                    {
                        Ref = "Ref " + i,
                        Surname = "Surname " + i,
                    });
                }

                var options = new BulkCopyOptions();

                db.BulkCopy(options, db.SourceTables.);
            }
        }

        [Benchmark]
        public void Add_Range_With_EF()
        {
            using (var db = new EF.EFDbContext())
            {
                var profiles = new List<EF.TargetTable>();
                for (int i = 0; i < N; i++)
                {
                    profiles.Add(new EF.TargetTable()
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
                db.TargetTables.AddRange(profiles);
                db.SaveChanges();
            }
        }

        [Benchmark]
        public void Add_Range_With_EFCore()
        {
            using (var db = new EFCore.EFCoreDbContex())
            {
                var profiles = new List<EFCore.Profile>();
                for (int i = 0; i < N; i++)
                {
                    profiles.Add(new EFCore.Profile()
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
                db.Profiles.AddRange(profiles);
                db.SaveChanges();
            }
        }


        [Benchmark]
        public void Bulk_Copy_With_EfCore_Linq2Db_Extension()
        {
            using (var db = new EFCoreLinq2DbExtension.EfCoreLinq2DbExtensionContext())
            {
                var profiles = new List<EFCoreLinq2DbExtension.Profile>();
                for (int i = 0; i < N; i++)
                {
                    profiles.Add(new EFCoreLinq2DbExtension.Profile()
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
                BulkCopyOptions bulkCopyOptions = new BulkCopyOptions();
            }
        }

        [Benchmark]
        public void Bulk_Copy_With_EfCore_Bulk_Extension()
        {
            using (var db = new EFCoreWithExtensions.Context())
            {
                var profiles = new List<EFCoreWithExtensions.Profiles>();
                for (int i = 0; i < N; i++)
                {
                    profiles.Add(new EFCoreWithExtensions.Profiles()
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
                db.BulkInsert(profiles);
            }
        }
    }
}