using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PuCore.Domain.Entities;
using PuCore.Utility.config;
using System;
using System.Linq;

namespace PuCore.EntityFramework.EntityFramework
{
    public class SeedData
    {
        public static void Initialize()
        {

            using (var context = new PuCoreDbContext(AppConfig.MySqlConnection))
            {
                if (context.Users.Any())
                {
                    return;   // 已经初始化过数据，直接返回
                }
                var department = new Department
                {
                    Name = "Pu集团总部",
                    ParentId = 0
                };
                //增加一个部门
                context.Departments.Add(department);
                //增加一个超级管理员用户
                context.Users.Add(
                     new User
                     {
                         UserName = "admin",
                         Password = "123456", //暂不进行加密
                         Name = "超级管理员",
                         DepartmentId = department.Id
                     }
                );
                //增加四个基本功能菜单
                context.Menus.AddRange(
                   new Menu
                   {
                       Name = "组织机构管理",
                       Code = "Department",
                       SerialNumber = 0,
                       ParentId = 0,
                       Icon = "fa fa-link"
                   },
                   new Menu
                   {
                       Name = "角色管理",
                       Code = "Role",
                       SerialNumber = 1,
                       ParentId = 0,
                       Icon = "fa fa-link"
                   },
                   new Menu
                   {
                       Name = "用户管理",
                       Code = "User",
                       SerialNumber = 2,
                       ParentId = 0,
                       Icon = "fa fa-link"
                   },
                   new Menu
                   {
                       Name = "功能管理",
                       Code = "Department",
                       SerialNumber = 3,
                       ParentId = 0,
                       Icon = "fa fa-link"
                   }
                );
                context.SaveChanges();
            }
        }
    }
}
