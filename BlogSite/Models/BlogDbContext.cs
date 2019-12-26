using BlogSite.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogSite.Models
{
    public class BlogDbContext:DbContext
    {
        public BlogDbContext():base("DefCon")
        {
            //Şimdi yazacağım kod ile Db de alan ekleme ya da çıkarma gibi değişim yapacağım zaman, sadece ilgili alanı güncellesin istiyorum.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogDbContext, Configuration>("DefCon"));
        }
        public DbSet<Makale> Makales { get; set; }
        public DbSet<Yazarlar> Yazarlars { get; set; }
        public DbSet<Kategoriler> Kategorilers { get; set; }

        public static BlogDbContext Create()
        {
            return new BlogDbContext();
        }
    }
}