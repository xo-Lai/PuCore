using AutoMapper;
using PuCore.Application.UserApp.Dtos;
using PuCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PuCore.Application
{
    /// <summary>
    /// Enity与Dto映射
    /// </summary>
    public class PuCoreMapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                //cfg.CreateMap<Menu, MenuDto>();
                //cfg.CreateMap<MenuDto, Menu>();
                //cfg.CreateMap<Department, DepartmentDto>();
                //cfg.CreateMap<DepartmentDto, Department>();
                //cfg.CreateMap<RoleDto, Role>();
                //cfg.CreateMap<Role, RoleDto>();
                //cfg.CreateMap<RoleMenuDto, RoleMenu>();
                //cfg.CreateMap<RoleMenu, RoleMenuDto>();
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<User, UserDto>();
                //cfg.CreateMap<UserRoleDto, UserRole>();
                //cfg.CreateMap<UserRole, UserRoleDto>();
            });
        }
    }
}
