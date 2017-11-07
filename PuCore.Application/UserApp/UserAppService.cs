using System;
using System.Collections.Generic;
using System.Text;
using PuCore.Application.UserApp.Dtos;
using PuCore.Domain.Entities;
using PuCore.Domain.IRepositories;
using AutoMapper;

namespace PuCore.Application.UserApp
{
    /// <summary>
    /// 用户管理服务
    /// </summary>
    public class UserAppService : IUserAppService
    {
        //用户管理仓储接口
        private readonly IUserRepository _repository;

        /// <summary>
        /// 构造函数 实现依赖注入
        /// </summary>
        /// <param name="userRepository">仓储对象</param>
        public UserAppService(IUserRepository userRepository)
        {
            _repository = userRepository;
        }
        public User CheckUser(string userName, string password)
        {
            return _repository.CheckUser(userName, password);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void DeleteBatch(List<int> ids)
        {
            _repository.Delete(it => ids.Contains(it.Id));
        }

        public UserDto Get(int id)
        {
            return Mapper.Map<UserDto>(_repository.GetWithRoles(id));
        }

        public List<UserDto> GetUserByDepartment(int departmentId, int startPage, int pageSize, out int rowCount)
        {
            return Mapper.Map<List<UserDto>>(_repository.LoadPageList(startPage, pageSize, out rowCount, it => it.DepartmentId == departmentId, it => it.CreateTime));
        }
        /// <summary>
        /// 新增或修改
        /// </summary>
        /// <param name="dto">实体</param>
        /// <returns></returns>
        public UserDto InsertOrUpdate(UserDto dto)
        {
            if (Get(dto.Id) != null)
                _repository.Delete(dto.Id);
            var user = _repository.InsertOrUpdate(Mapper.Map<User>(dto));
            return Mapper.Map<UserDto>(user);
        }
    }
}
