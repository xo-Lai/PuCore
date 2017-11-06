using PuCore.Domain.Entities;
using PuCore.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using PuCore.EntityFramework.EntityFramework;

namespace PuCore.EntityFramework.Repositories
{
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(PuCoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
