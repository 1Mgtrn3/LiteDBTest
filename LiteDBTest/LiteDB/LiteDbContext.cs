using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LiteDBTest
{
    public class LiteDbContext: DbContext
    {
        public readonly LiteDatabase Context;
        
        public LiteDbContext(IOptions<LiteDbConfig> configs)
        {
            try
            {
                var db = new LiteDatabase(configs.Value.DatabasePath);
                if (db != null)
                    Context = db;
            }
            catch (Exception ex)
            {
                throw new Exception("Can't find or create LiteDb database.", ex);
            }
        }
    }
}
