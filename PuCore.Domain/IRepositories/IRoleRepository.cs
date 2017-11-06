using PuCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PuCore.Domain.IRepositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        /// <summary>
        /// 根据角色获取权限
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <returns></returns>
        List<int> GetAllMenuListByRole(int roleId);

        /// <summary>
        /// 更新角色权限关联关系
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="roleMenus">角色权限集合</param>
        /// <returns></returns>
        bool UpdateRoleMenu(int roleId, List<RoleMenu> roleMenus);
    }
}
