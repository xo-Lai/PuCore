using PuCore.Application.UserApp.Dtos;
using PuCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PuCore.Application.UserApp
{
    public interface IUserAppService
    {
        User CheckUser(string userName, string password);

        List<UserDto> GetUserByDepartment(int departmentId, int startPage, int pageSize, out int rowCount);

        UserDto InsertOrUpdate(UserDto dto);

        /// <summary>
        /// 根据Id集合批量删除
        /// </summary>
        /// <param name="ids">Id集合</param>
        void DeleteBatch(List<int> ids);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">Id</param>
        void Delete(int id);

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        UserDto Get(int id);
    }
}
