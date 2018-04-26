﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Zxw.Framework.NetCore.Options;

namespace Zxw.Framework.NetCore.DbContextCore
{
    public class PostgreSQLDbContext:BaseDbContext
    {
        public PostgreSQLDbContext(IOptions<DbContextOption> option) : base(option)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_option.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}