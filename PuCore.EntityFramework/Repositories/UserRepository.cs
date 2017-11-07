using PuCore.Domain.Entities;
using PuCore.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using PuCore.EntityFramework.EntityFramework;
using System.Linq;

namespace PuCore.EntityFramework.Repositories
{
    /// <summary>
    /// 用户管理仓储实现
    /// </summary>
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(PuCoreDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// 检查用户是存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>存在返回用户实体，否则返回NULL</returns>
        public User CheckUser(string userName, string password)
        {
            return _dbContext.Set<User>().FirstOrDefault(it => it.UserName == userName && it.Password == password);
        }

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public User GetWithRoles(int id)
        {
            var user = _dbContext.Set<User>().FirstOrDefault(it => it.Id == id);
            if (user != null)
            {
                user.UserRoles = _dbContext.Set<UserRole>().Where(it => it.UserId == id).ToList();
            }
            return user;
        }
    }
}
