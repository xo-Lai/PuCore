using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using PuCore.Domain.Entities;

namespace PuCore.EntityFramework.EntityFramework
{
    public class PuCoreDbContext : DbContext
    {
        public PuCoreDbContext( DbContextOptions<PuCoreDbContext> options) : base(options)
        {
        }
        private string connection;
        public PuCoreDbContext(string connection) => this.connection = connection;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrWhiteSpace(connection))
                optionsBuilder.UseMySql(connection);

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //UserRole关联配置
            builder.Entity<UserRole>()
              .HasKey(ur => new { ur.UserId, ur.RoleId });

            //RoleMenu关联配置
            builder.Entity<RoleMenu>()
              .HasKey(rm => new { rm.RoleId, rm.MenuId });

           

            base.OnModelCreating(builder);
        }
    }
}
