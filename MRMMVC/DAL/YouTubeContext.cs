using MRMMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;


namespace MRMMVC.DAL
{
    public class YouTubeContext : DbContext
    {
        public YouTubeContext() : base("YouTubeContext")
        {

        }
        public DbSet<YouTubeDetail> YouTubeDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}