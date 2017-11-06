using PuCore.Domain.Entities;
using PuCore.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using PuCore.EntityFramework.EntityFramework;

namespace PuCore.EntityFramework.Repositories
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(PuCoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
