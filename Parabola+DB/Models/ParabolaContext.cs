using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ParabolaDB.Models
{
    public class ParabolaContext : DbContext
    {
        public DbSet<Param> Params { get; set; }
        public DbSet<CacheData> CacheDatas { get; set; }
    }
}